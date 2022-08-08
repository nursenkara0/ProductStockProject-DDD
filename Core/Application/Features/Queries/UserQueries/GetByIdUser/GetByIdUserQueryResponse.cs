using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Queries.UserQueries.GetByIdUser
{
    public class GetByIdUserQueryResponse
    {
        public Guid Id;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        // public string Password { get; set; }
    }
}
