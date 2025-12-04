using December.Domain.Entities;

namespace December.Application.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTOResponse>> GetAll();
        Task<PersonDTOResponse?> GetById(int id);
        Task<PersonDTOResponse?> Create(PersonDTORequest person);
        Task<PersonDTOResponse?> Update(PersonDTORequest person);
    }
}
