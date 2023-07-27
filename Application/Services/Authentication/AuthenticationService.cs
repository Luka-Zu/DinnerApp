
using DinnerApp.Api.Common.Interfaces.Authentication;
using DinnerApp.Application.Common.Interfaces.Persistence;
using DinnerApp.Domain.Entities;

namespace DinnerApp.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;

        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public AuthenticationResult Login(string email, string password)
        {
            // TO-DO 
            // Validate that user exists
            if (_userRepository.GetByEmail(email) is not User User)
            {
                throw new Exception("User with given email does not exist.");
            }

            // validate that password is correct
            if (User.Password != password)
            {
                throw new Exception("Invalid password.");
            }
            // create JWT token 
            var Token = _jwtTokenGenerator.GenerateToken(User);


            return new AuthenticationResult(User, Token);
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {

            // check if user exists 
            if ( _userRepository.GetByEmail(email) is not null)
            {
                throw new Exception("User with given Email already exists.");
            }


            // Generete User (unique ID)
            var User = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password
            };
            _userRepository.Add(User);

            // Create Jwt Token 
            
            var Token = _jwtTokenGenerator.GenerateToken(User);
      

            return new AuthenticationResult(User, Token);
        }
    }
}
