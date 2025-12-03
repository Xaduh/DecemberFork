namespace December.Application.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTOResponse>> GetAll();
    }
}
