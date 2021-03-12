using DAL.ModelsDAL.Serivces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.TestRepository
{
    static class ServiceInfoRepository
    {
        public static List<ServiceInfo> getSerivecesInfo() 
        {
            var si = new List<ServiceInfo>();

            si.Add(new ServiceInfo()
            {
                Id = 1,
                Name = "Обслуживание КлиентТК",
                MainCost = 23.5,
                AdditionalCost = 15.3,
                Description = "Консультации, удалённая поддержка. При необходимости выезд к клиенту"
            });
            si.Add(new ServiceInfo()
            {
                Id = 2,
                Name = "Обслуживание ГРС",
                MainCost = 19.3,
                AdditionalCost = 14.2,
                Description = "Установкаю, консультации, удалённая поддержка. При необходимости выезд к клиенту."
            });
            si.Add(new ServiceInfo()
            {
                Id = 3,
                Name = "Сопровождение вычислительно техники",
                MainCost = 32.16,
                AdditionalCost = 26.3,
                Description = "Обслуживание техники. Ежемесечная проверка с диагностикой на месте эксплуатации."
            });
            si.Add(new ServiceInfo()
            {
                Id = 4,
                Name = "Удалённое сопровождение вычислительно техники",
                MainCost = 25.86,
                AdditionalCost = 21.6,
                Description = "Удалённое бслуживание техники без выезда на место"
            });
            return si;
        }
    }
}
