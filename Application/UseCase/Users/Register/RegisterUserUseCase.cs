using Communication.Requests;
using Communication.Responses;
using Infrastructure.Models;
using Infrastructure.Repositories;

namespace Application.UseCase.Users.Register
{
    public class RegisterUserUseCase
    {
        private readonly InterfaceUser _repository;

        public RegisterUserUseCase(InterfaceUser repository)
        {
            _repository = repository;
        }

        public async Task<RegisterUserResponse> Execute(RegisterUserRequest request)
        {
            // Verifica se o e-mail já existe
            var existingUser = await _repository.GetUserByEmail(request.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists");
            }

            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
                Password = request.Password,
            };

            // Cria o novo usuário usando o repositório
            await _repository.CreateUser(user);

            return new RegisterUserResponse
            {
                Id = user.Id,
                Name = request.Name,
            };
        }
    }
}