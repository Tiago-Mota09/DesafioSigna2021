using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeafioSigna2021.Domain.Models.Request
{
    public class LikedRepositoryRequest
    {
        public string IdRepository { get; set; }
        public bool Status { get; set; }
    }
}
