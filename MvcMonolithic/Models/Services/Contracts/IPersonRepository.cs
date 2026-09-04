using MvcMonolithic.Models.DomainModels.PersonAggregate;

namespace MvcMonolithic.Models.Services.Contracts
{
    public interface IPersonRepository
    {
        Task<List<Person>> SelectAll();
    }
}
