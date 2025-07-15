using System.Text.RegularExpressions;
using UsersApi.Extensions;

namespace UsersApi.Models;

public sealed class User
{
    private static readonly Regex _emailRegex =
        new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.Compiled);

    private DateOnly _dateOfBirth;
    private string _email = null!;
    private string _fullName = null!;

    public User(string fullName, string email, DateOnly dateOfBirth)
    {
        FullName = fullName;
        Email = email;
        DateOfBirth = dateOfBirth;
    }

    public int Id { get; set; }

    public string FullName
    {
        get => _fullName;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 2)
                throw new ArgumentException("Full name must be at least 2 characters long.", nameof(FullName));

            _fullName = value;
        }
    }

    public string Email
    {
        get => _email;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || !_emailRegex.IsMatch(value))
                throw new ArgumentException("Invalid email format.", nameof(Email));
            _email = value;
        }
    }

    public DateOnly DateOfBirth
    {
        get => _dateOfBirth;
        set
        {
            if (!value.IsNotInFuture()) throw new ArgumentException("Date of birth cannot be in the future.");

            _dateOfBirth = value;
        }
    }
}