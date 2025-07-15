using UsersApi.Models;

namespace UsersApi.Repositories.Interfaces;

public interface IUserRepository
{
    public List<User> GetAll();
    public void Create(User user);
    public User GetById(int id);
    public void Delete(int id);
}