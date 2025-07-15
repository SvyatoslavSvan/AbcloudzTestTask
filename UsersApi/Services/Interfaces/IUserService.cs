using UsersApi.Models;

namespace UsersApi.Services.Interfaces;

public interface IUserService
{
    List<User> GetAll();
    public void Create(User user);
    public User GetById(int id);
    public void Delete(int id);
}