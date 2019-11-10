using System.Collections.Generic;
using System.Linq;
using CRUD.Models.Repository;

namespace CRUD.Models.DataManager
{
    /// <summary>
    /// Handles all database operations related to the user. The purpose of this class is to separate the actual data operations logic from API Controller.
    /// </summary>
    public class UserManager : IDataRepository<User>
    {
        private readonly RepositoryContext repositoryContext;

        public UserManager(RepositoryContext rcontext)
        {
            this.repositoryContext = rcontext;
        }

        public void Add(User entity)
        {
            repositoryContext.Users.Add(entity);
            repositoryContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            repositoryContext.Users.Remove(entity);
            repositoryContext.SaveChanges();
        }

        public User Get(int id)
        {
            return repositoryContext.Users.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return repositoryContext.Users.ToList();
        }

        public void Update(User dbEntity, User entity)
        {
            dbEntity.Name = entity.Name;
            dbEntity.Age = entity.Age;
            dbEntity.PhoneNumber = entity.PhoneNumber;
            dbEntity.Email = entity.Email;
            repositoryContext.SaveChanges();
        }
    }
}
