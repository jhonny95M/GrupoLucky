using Lucky.Entities.Interfaces;
using Lucky.UseCases.CreateUser;
using Lucky.UseCasesDtos;
using MediatR;

namespace Lucky.UseCases.ReadUser
{
    public class ReadUserInteractor : IRequestHandler<ReadUserOuputPortQuery,ReadUserOuputPort>
    {
        private readonly IUserRepository userRepository;
        private readonly IUnitOfWork unitOfWork;

        public ReadUserInteractor(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<ReadUserOuputPort> Handle(ReadUserOuputPortQuery request, CancellationToken cancellationToken)
        {
            var rs=new ReadUserOuputPort();
            rs.UserParams=new List<CreateUserParams>();
            var users = await userRepository.GetAll();
            if (users != null)
            {
                foreach (var user in users)
                {
                    rs.UserParams.Add(new CreateUserParams
                    {
                        Email = user.Email,
                        Id = user.Id,
                        UserName = user.UserName,
                    });
                }
            }
            return rs;
        }

        //public async Task<IEnumerable<ReadUserOuputPort>> Handle(ReadUserOuputPortQuery request, CancellationToken cancellationToken)
        //{
        //    var users=await userRepository.GetAll();
        //    if (users != null)
        //    {
        //        foreach (var user in users)
        //        {
        //            yield return new ReadUserOuputPort
        //            {
        //                Email = user.Email,
        //                Id = user.Id,
        //                UserName = user.UserName,
        //            };
        //        }
        //    }
        //}
    }
}
