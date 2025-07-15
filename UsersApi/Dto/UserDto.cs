using System.ComponentModel.DataAnnotations;
using UsersApi.Models;
using UsersApi.Validation;

namespace UsersApi.Dto;

public sealed class UserDto
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Full name is required")]
    [MinLength(2, ErrorMessage = "Full name must be at least 2 characters long")]
    public required string FullName { get; set; }

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Date of birth is required")]
    [DateOnlyNotInFuture]
    public DateOnly DateOfBirth { get; set; }

    public User ToUser() => new(FullName, Email, DateOfBirth);
}