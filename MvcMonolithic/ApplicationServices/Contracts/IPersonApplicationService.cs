using MvcMonolithic.ApplicationServices.Dtos;

namespace MvcMonolithic.ApplicationServices.Contracts
{
    public interface IPersonApplicationService
    {
        Task<List<GetPersonDto>> GetAllPerson();
        Task<PutPersonDto?> GetById(int id);
        Task Post(PostPersonDto postPersonDto);
        Task Put(PutPersonDto putPersonDto);
    }
}
