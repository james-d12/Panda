using Panda.Application.Common.Interfaces.Authentication;
using Panda.Application.Common.Interfaces.Persistence;
using Panda.Domain.Entities;

namespace Panda.Application.Services.Authentication;

public sealed class AuthenticationService : IAuthenticationService
{ 
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists!");
        }

        var user = new User
        { 
            FirstName = firstName, 
            LastName = lastName, 
            Email = email, 
            Password = password 
        };

        _userRepository.Add(user);

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }

    public AuthenticationResult Login(string email, string password)
    {
        if(_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("Credentials are invalid");
        }

        if(user.Password != password)
        {
            throw new Exception("Invalid Password");
        }

        var token = _jwtTokenGenerator.GenerateToken(user);
        return new AuthenticationResult(user, token);
    }
}