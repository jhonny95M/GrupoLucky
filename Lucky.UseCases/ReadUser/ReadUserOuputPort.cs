using Lucky.UseCasesDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucky.UseCases.ReadUser
{
    public class ReadUserOuputPort: CreateUserParams
    {
        public List<CreateUserParams> UserParams { get; set; }
    }
    public class ReadUserOuputPortQuery: IRequest<ReadUserOuputPort>
    {
        
    }
}
