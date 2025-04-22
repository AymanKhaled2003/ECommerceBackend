using Common.Application.Abstractions.Messaging;
using ECommerce.Applicatoin.Features.Auth.Command.Login;
using ECommerce.Domain.Interfaces;
using ECommerce.Domain.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Application.Features.Auth.Command.Login
{
    public class LoginCommandHandler : ICommandHandler<LoginCommand>
    {
        private readonly IAuthenticationService _authService;

        public LoginCommandHandler(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public async Task<ResponseModel> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _authService.AuthenticateAsync(request.Email, request.Password);

            if (user == null)
            {
                return ResponseModel.Failure("Invalid username or password");
            }

            var token = _authService.Generate(user);
            return ResponseModel.Success(token); // Include token in response
        }
    }
}
