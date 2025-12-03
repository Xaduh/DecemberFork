namespace December.Application.Services
{
    public class PersonService : IPersonService
    {
        public IPersonRepository context;
        public PersonService(IPersonRepository c) { context = c; }

        public async Task<IEnumerable<PersonDTOResponse>> GetAll()
        {
            return await context.GetAll().ContinueWith(p => p.Result.Select(r => new PersonDTOResponse
            {
                Id = r.Id,
                Name = r.Name,
                Mail = r.Mail
            }));
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
