using Lucky.Entities;

namespace Lucky.UseCasesDtos
{
    public class CreateUserParams:User
    {
        public string Opcional { get; set; }
    }
}