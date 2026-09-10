using MvcMonolithic.ApplicationServices.Contracts;
using MvcMonolithic.ApplicationServices.Dtos;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.ApplicationServices
{
    public class PersonApplicationService : IPersonApplicationService
    {
        private readonly IPersonRepository _personRepository;

        #region [- Ctor -]
        public PersonApplicationService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        #endregion

        #region [- Post() -]
        public async Task Post(PostPersonDto postPersonDto)
        {
            var person = new Models.DomainModels.PersonAggregate.Person()
            {
                Id = postPersonDto.Id,
                FirstName = postPersonDto.FirstName,
                LastName = postPersonDto.LastName,
            };
            await _personRepository.Insert(person);
        }
        #endregion

        #region [- GetAllPerson() -]
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
        #endregion
    }
}
