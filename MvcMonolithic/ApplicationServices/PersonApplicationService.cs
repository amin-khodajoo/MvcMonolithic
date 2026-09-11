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

        #region [- Put() -]
        public async Task Put(PutPersonDto putPersonDto)
        {
            var person = new Models.DomainModels.PersonAggregate.Person()
            {
                Id = putPersonDto.Id,
                FirstName = putPersonDto.FirstName,
                LastName = putPersonDto.LastName,
            };
            await _personRepository.Edit(person);
        }
        #endregion

        #region [- GetById() -]
        public async Task<PutPersonDto?> GetById(int id)
        {
            var person = await _personRepository.SelectById(id);
            if (person == null)
            {
                return null;
            }

            var putPersonDto = new PutPersonDto()
            {
                Id = person.Id,
                FirstName = person.FirstName,
                LastName = person.LastName,
            };

            return putPersonDto;
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
