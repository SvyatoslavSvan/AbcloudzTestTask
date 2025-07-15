using UsersApi.Models;
using UsersApi.Repositories.Interfaces;
using UsersApi.Services.Interfaces;

namespace UsersApi.Services.Implementations;

public sealed class UserService(IUserRepository repository) : IUserService
{
    public List<User> GetAll() => repository.GetAll();

    public void Create(User user) => repository.Create(user);

    public User GetById(int id) => repository.GetById(id);

    public void Delete(int id) => repository.Delete(id);
}