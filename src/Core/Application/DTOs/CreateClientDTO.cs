using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public static class CreateClientDTO
    {
        public class Input
        {
            [Required]
            public required string FirstName { get; set; }

            [Required]
            public required string LastName { get; set; }

            [Required]
            public int Participation { get; set; }
        }
    }
}
