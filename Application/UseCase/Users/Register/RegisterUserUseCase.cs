using Communication.Requests;
using Communication.Responses;
using Infrastructure.Data;
using Infrastructure.Models;

namespace Application.UseCase.Users.Register
{
    public class RegisterUserUseCase
    {
        private readonly UserDbContext _context;

        public RegisterUserUseCase(UserDbContext context)
        {
            _context = context;
        }

        public RegisterUserResponse Execute(RegisterUserRequest request)
        {
            var emailExist = _context.Users.FirstOrDefault(x => x.Email == request.Email);

            if (emailExist != null) 
            {
                throw new Exception("Email already exists");
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return new RegisterUserResponse
            {
                Id = user.Id,
                Name = request.Name,
            };

            
        }
    }
}
