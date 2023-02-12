namespace Panda.Contracts.Authentication;

public record AuthenticationResponse(
    Guid Id,
    string Firstname,
    string LastName,
    string Email,
    string Token
);