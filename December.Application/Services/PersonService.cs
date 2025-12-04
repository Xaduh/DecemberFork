using December.Domain.Entities;

namespace December.Application.Services
{
    public class PersonService : IPersonService
    {
        public IPersonRepository context;
        public PersonService(IPersonRepository c) { context = c; }

        public async Task<PersonDTOResponse?> Create(PersonDTORequest person)
        {
            foreach (var item in typeof(PersonDTORequest).GetProperties())
            {
                var personCheck = item.GetValue(person);
                if (personCheck == null || personCheck.ToString() == "") return null;
            }

            Person? personCreate = new Person()
            {
                Name = person.Name,
                Lastname = person.Lastname,
                Mail = person.Mail
            };

            Person personReturn = await context.Create(personCreate);
            return new PersonDTOResponse
            {
                Id = personReturn.Id,
                Name = personReturn.Name,
                Mail = personReturn.Mail
            };
        }

        public async Task<IEnumerable<PersonDTOResponse>> GetAll()
        {
            return await context.GetAll().ContinueWith(p => p.Result.Select(r => new PersonDTOResponse
            {
                Id = r.Id,
                Name = r.Name,
                Mail = r.Mail
            }));
        }

        public async Task<PersonDTOResponse?> GetById(int id)
        {
            Person? person = context.GetById(id).Result;
            if (person == null) return null;
            return await Task.FromResult<PersonDTOResponse?>(new PersonDTOResponse
            {
                Id = person.Id,
                Name = person.Name,
                Mail = person.Mail
            });
        }

        public async Task<PersonDTOResponse?> Update(PersonDTORequest person)
        {
            Person? personCurrent = await context.GetById(person.Id);
            if (personCurrent == null) return null;
            Person personUpdate = new Person()
            {
                Id = person.Id,
                /* en betinget tildeling eller en ternær operator (?:) eller shortform if-else. Denne skrives i en linje, opdelt i 2, på hvert side af ?.
                 * Venstre side af ? er conditions. Højre side er true : false */
                Name = person.Name != "" && person.Name != null ? person.Name : personCurrent.Name,
                Lastname = person.Lastname != "" && person.Lastname != null ? person.Lastname : personCurrent.Lastname,
                Mail = person.Mail != "" && person.Mail != null ? person.Mail : personCurrent.Mail
            };
            Person personReturn = await context.Update(personUpdate);
            return new PersonDTOResponse
            {
                Id = personReturn.Id,
                Name = personReturn.Name,
                Mail = personReturn.Mail
            };
        }

        /*
         * return await clanRepository.GetallClans().ContinueWith(t => t.Result.Select(c => new ClanDTOResponse
            {
                ClanId = c.ClanId,
                Name = c.Name,
                Crest = c.Crest
            }));
         */
            }
}
