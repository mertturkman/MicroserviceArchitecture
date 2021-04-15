using User.Application.Abstractions.Query;

namespace User.Application.Commands
{
    public class TokenValidationQuery: IQuery
    {
        public string Mail { get; set; }
        public string Token { get; set; }
    }
}
