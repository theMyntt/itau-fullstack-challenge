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
            [RegularExpression(@"^\S*$", ErrorMessage = "First name cannot contain spaces.")]
            public required string FirstName { get; set; }

            [Required]
            public required string LastName { get; set; }

            [Required]
            [Range(1, 100)]
            public int Participation { get; set; }
        }
    }
}
