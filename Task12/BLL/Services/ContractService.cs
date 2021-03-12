using AutoMapper;
using BLL.Interfaces;
using BLL.ModelsBLL;
using BLL.ModelsDTO;
using BLL.ModelsDTO.Serivces;
using DAL;
using DAL.ModelsDAL;
using DAL.ModelsDAL.Serivces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ContractService : IContractsServiceRepository
    {
        public async Task<List<ContractInfo>> GetFullContractOnOrganization(int organizationId)
        {
            List<ContractInfo> fullInfo = new List<ContractInfo>();
            List<Contract> orgContracts;
            using (var context = new ContractContext())
            {
                orgContracts = await context.Contracts.Where(con => con.OrganizationId == organizationId).AsNoTracking().ToListAsync();
            }
            foreach (var contract in orgContracts)
            {
                var hardwareTask = await HardwaresForContractAsync(contract);
                var softwareTask = await SoftwaresForContractAsynk(contract);
                fullInfo.Add(
                    new ContractInfo()
                    {
                        Id = contract.Id,
                        Number = contract.Number,
                        StartDate = contract.StartDate,
                        EndDate = contract.EndDate,
                        HardwareForInfo = hardwareTask,
                        SoftwareForInfo = softwareTask

                    }
                );
            }
            return fullInfo;
        }

        public async Task AddContract(ContractDTO contractDTO, List<ServiceHardwareDTO> hardwaresDTO, List<ServiceSoftwareDTO> softwaresDTO)
        {
            var configContract = new MapperConfiguration(cfg => cfg.CreateMap<ContractDTO, Contract>());
            var configHardwares = new MapperConfiguration(cfg => cfg.CreateMap<ServiceHardwareDTO, ServiceHardware>());
            var configSoftwares = new MapperConfiguration(cfg => cfg.CreateMap<ServiceSoftwareDTO, ServiceSoftware>());

            var mapperContract = new Mapper(configContract);
            var mapperHardwares = new Mapper(configHardwares);
            var mapperSoftwares = new Mapper(configSoftwares);

            Contract contract = mapperContract.Map<Contract>(contractDTO);
            List<ServiceHardware> hardwares = mapperHardwares.Map<List<ServiceHardware>>(hardwaresDTO);
            List<ServiceSoftware> softwares = mapperSoftwares.Map<List<ServiceSoftware>>(softwaresDTO);
            contract.ServicesHardware = hardwares;
            contract.ServicesSoftware = softwares;

            using (ContractContext context = new ContractContext())
            {
                await context.Contracts.AddAsync(contract);
                await context.SaveChangesAsync();
            }
        }

        public async Task<double> GetCostOnPeriod(int areaId, DateTime startFilter, DateTime endFilter)
        {
            double fullCost = 0;
            List<Contract> contracts;
            using (ContractContext context = new ContractContext())
            {
                // Where Is filter contract on crossing date. If contract started and ended before filter it skip
                contracts = await context.Contracts.Where(c => c.Organization.AreaId == areaId).Include(c => c.ServicesHardware).ThenInclude(sh => sh.ServiceInfo).
                     Include(c => c.ServicesSoftware).ThenInclude(sh => sh.ServiceInfo).
                     Where((c => (!((startFilter < c.StartDate && endFilter < c.StartDate) || (startFilter > c.EndDate && endFilter > c.EndDate))))).
                     AsNoTracking().ToListAsync();
            }
            fullCost += GetCostHardware(contracts, startFilter, endFilter);
            fullCost += GetCostSoftware(contracts, startFilter, endFilter);
            return fullCost;
        }
        private double GetCostSoftware(List<Contract> contracts, DateTime startFilter, DateTime endFilter)
        {
            double sum = 0;
            foreach (var contract in contracts)
            {
                var month = GetMonthActionContract(contract, startFilter, endFilter);
                foreach (var software in contract.ServicesSoftware)
                {
                    var serviceInfo = software.ServiceInfo;

                    sum += software.MainPlaceCount * serviceInfo.MainCost * month;
                    sum += software.AdditionalPlaceCount * serviceInfo.AdditionalCost * month;
                }
            }
            return sum;
        }

        private double GetCostHardware(List<Contract> contracts, DateTime startFilter, DateTime endFilter)
        {
            double sum = 0;
            foreach (var contract in contracts)
            {
                var month = GetMonthActionContract(contract, startFilter, endFilter);
                foreach (var software in contract.ServicesHardware)
                {
                    var serviceInfo = software.ServiceInfo;

                    sum += software.ServerCount * serviceInfo.MainCost * month;
                    sum += software.WorkplaceCount * serviceInfo.AdditionalCost * month;
                }
            }
            return sum;
        }
        private int GetMonthActionContract(Contract contract, DateTime startFilter, DateTime endFilter)
        {
            DateTime maxStart = startFilter;
            DateTime minEnd = endFilter;
            if (DateTime.Compare(contract.StartDate, startFilter) > 0) maxStart = contract.StartDate;
            if (DateTime.Compare(contract.EndDate ?? endFilter, endFilter) < 0) minEnd = contract.EndDate ?? endFilter;
            int month = ( minEnd.Year - maxStart.Year) * 12 + minEnd.Month - maxStart.Month;
            return month;
        }
        private async Task<List<HardwareForInfo>> HardwaresForContractAsync(Contract contract)
        {
            List<HardwareForInfo> hardwares = new List<HardwareForInfo>();
            using (var context = new ContractContext())
            {
                hardwares = await context.ServiceHardwares.Where(hard => hard.ContractId == contract.Id).Include(info => info.ServiceInfo).
                   Select(item => new HardwareForInfo()
                    {
                        ServerCount = item.ServerCount,
                        WorkplaceCount = item.WorkplaceCount,
                        ServiceInfoName = item.ServiceInfo.Name
                    }).AsNoTracking().ToListAsync();
            }
            return hardwares;
        }

        private async Task<List<SoftwareForInfo>> SoftwaresForContractAsynk(Contract contract)
        {
            List<SoftwareForInfo> softwares = new List<SoftwareForInfo>();
            using (var context = new ContractContext())
            {
                softwares = await context.ServiceSoftwares.Where(hard => hard.ContractId == contract.Id).Include(info => info.ServiceInfo).
                     Select(item => new SoftwareForInfo()
                    {
                        MainPlaceCount = item.MainPlaceCount,
                        AdditionalPlaceCount = item.AdditionalPlaceCount,
                        ServiceInfoName = item.ServiceInfo.Name
                    }).AsNoTracking().ToListAsync();
            }
            return softwares;
        }
    }

}
