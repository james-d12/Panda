using Panda.Domain.Entities;

namespace Panda.Application.Services.Authentication
{
    public record AuthenticationResult(
        User User,
        string Token
    );
}
