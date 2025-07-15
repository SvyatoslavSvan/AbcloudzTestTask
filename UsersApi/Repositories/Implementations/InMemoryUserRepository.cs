using System.Collections.Concurrent;
using UsersApi.Models;
using UsersApi.Repositories.Interfaces;

namespace UsersApi.Repositories.Implementations;

public sealed class InMemoryUserRepository : IUserRepository
{
    private static readonly ConcurrentDictionary<int, User> _users;

    private static int _nextId;

    static InMemoryUserRepository() => _users = new ConcurrentDictionary<int, User>();

    public List<User> GetAll() => _users.Values.ToList();

    public void Create(User user)
    {
        ArgumentNullException.ThrowIfNull(user);
        HandleUserCreationError(user, SetUserId(user));
    }

    public User GetById(int id) => _users[id];

    public void Delete(int id)
    {
        if (!_users.TryRemove(id, out _)) throw new InvalidOperationException("Error deleting user");
    }

    private static void HandleUserCreationError(User user, int id)
    {
        if (!_users.TryAdd(id, user)) throw new InvalidOperationException("Error adding user");
    }

    private static int SetUserId(User user)
    {
        var id = Interlocked.Increment(ref _nextId);
        user.Id = id;
        return id;
    }
}