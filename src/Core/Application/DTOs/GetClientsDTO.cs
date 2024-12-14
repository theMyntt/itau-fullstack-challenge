using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.DTOs
{
    public static partial class GetClientsDTO
    {
        public class Input
        {
            [Required]
            public int Page { get; set; }
        }

        public partial class Output
        {
            public string Message { get; set; } = string.Empty;
            public int StatusCode { get; set; }
            public int Page { get; set; }
            public int TotalPages { get; set; }
            public IEnumerable<ClientEntity> Clients { get; set; } = [];
        }
    }
}
