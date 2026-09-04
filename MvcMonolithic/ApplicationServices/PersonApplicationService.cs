using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.ApplicationServices
{
    public class PersonApplicationService : IPersonApplicationService
    {
        private readonly IPersonRepository _personRepository;

        public PersonApplicationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<GetPersonDto>> GetAllPerson()
        {
            var persons = await _personRepository.SelectAll();
            var getPersonDtos = new List<GetPersonDto>();
            foreach (var item in persons)
            {
                var getPersonDto = new GetPersonDto()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                };
                getPersonDtos.Add(getPersonDto);

            }
                return getPersonDtos;
        }
    }
}
