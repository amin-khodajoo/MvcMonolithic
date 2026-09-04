using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModels.PersonAggregate;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {
		private readonly ProjectDbContext _projectDbContext;

        public PersonRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }

        public async Task<List<Person>> SelectAll()
        {
			try
			{
				return await _projectDbContext.Person.ToListAsync();
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
