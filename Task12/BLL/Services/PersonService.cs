using AutoMapper;
using BLL.Interfaces;
using BLL.ModelsBLL;
using BLL.ModelsDTO;
using DAL;
using DAL.ModelsDAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class PersonService : IPersonServiceRepository
    {
        public async Task<List<PersonWithOrgName>> GetPersonWithOrg()
        {
            var personWithOrgName = new List<PersonWithOrgName>();
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Person, PersonDTO>());
            var mapper = new Mapper(config);
            using (ContractContext context = new ContractContext())
            {
                personWithOrgName = await context.People.OrderBy(p => p.LastName).AsNoTracking().Select(p => new PersonWithOrgName()
                {
                    Person = mapper.Map<PersonDTO>(p),
                    OrgName = p.Organization.Name
                }).ToListAsync(); ;
            }
            return personWithOrgName;
        }

        public async Task AddPerson(PersonDTO personDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PersonDTO, Person>());
            var mapper = new Mapper(config);
            using (ContractContext context = new ContractContext())
            {
                await context.People.AddAsync(mapper.Map<Person>(personDTO));
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdatePerson(PersonDTO personDTO)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<PersonDTO, Person>());
            var mapper = new Mapper(config);
            using (ContractContext context = new ContractContext())
            {
                var person = await context.People.Where(p => p.Id == personDTO.Id).FirstOrDefaultAsync(); ;
                if (!person.FirstName.Equals(personDTO.FirstName)) person.FirstName = personDTO.FirstName;
                if (!person.LastName.Equals(personDTO.LastName)) person.LastName = personDTO.LastName;
                if (!person.MiddleName.Equals(personDTO.MiddleName)) person.MiddleName = personDTO.MiddleName;
                if (!person.Position.Equals(personDTO.Position)) person.Position = personDTO.Position;
                if (!person.Phone.Equals(personDTO.Phone)) person.Phone = personDTO.Phone;
                if (!person.Email.Equals(personDTO.Email)) person.Email = personDTO.Email;
                if (!person.MobilePhone?.Equals(personDTO.MobilePhone) ?? true) person.MobilePhone = personDTO.MobilePhone;

                await context.SaveChangesAsync();
            }
        }
    }
}
