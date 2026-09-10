using MvcMonolithic.ApplicationServices.Dtos;

namespace MvcMonolithic.ApplicationServices.Contracts
{
    public interface IPersonApplicationService
    {
        Task<List<GetPersonDto>> GetAllPerson();
        Task Post(PostPersonDto postPersonDto);
    }
}
