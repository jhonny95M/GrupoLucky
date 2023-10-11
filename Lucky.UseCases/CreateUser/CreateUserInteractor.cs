using Lucky.Entities;
using Lucky.Entities.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucky.UseCases.CreateUser
{
    public class CreateUserInteractor : IRequestHandler<CreateUserInputPort, int>
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateUserInteractor(IUserRepository userRepository,IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<int> Handle(CreateUserInputPort request, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Email = request.Email,
                PasswordHash = request.PasswordHash,
                UserName = request.UserName,
            };
            await userRepository.CreateAsync(user);
            await unitOfWork.SaveChangeAsync();
            return user.Id;
        }
    }
}
