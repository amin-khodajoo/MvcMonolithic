using Microsoft.EntityFrameworkCore;
using MvcMonolithic.Models.DomainModels.PersonAggregate;
using MvcMonolithic.Models.Services.Contracts;

namespace MvcMonolithic.Models.Services.Repositories
{
    public class PersonRepository : IPersonRepository
    {
		private readonly ProjectDbContext _projectDbContext;

        #region [- Ctor -]
        public PersonRepository(ProjectDbContext projectDbContext)
        {
            _projectDbContext = projectDbContext;
        }
        #endregion

        #region [- Insert() -]
        public async Task Insert(Person person)
        {
            try
            {
                _projectDbContext.Add(person);
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- Edit() -]
        public async Task Edit(Person person)
        {
            try
            {
                _projectDbContext.Update(person);
                await _projectDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region [- SelectAll() -]
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
        #endregion

        #region [- SelectById() -]
        public async Task<Person?> SelectById(int id)
        {
            try
            {
                return await _projectDbContext.Person.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
