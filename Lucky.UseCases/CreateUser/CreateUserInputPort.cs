using Lucky.Entities;
using Lucky.UseCasesDtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lucky.UseCases.CreateUser
{
    public class CreateUserInputPort : CreateUserParams, IRequest<int>
    {
    }
}
