namespace Panda.Contracts.Authentication;

public record RegisterRequest(
    string Firstname,
    string LastName,
    string Email,
    string Password
);