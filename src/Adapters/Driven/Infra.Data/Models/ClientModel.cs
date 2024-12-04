using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Entities
{
    [Table("TBL_CLIENTS")]
    public class ClientModel
    {
        [Key]
        [Column("ID_CLIENT")]
        public required Guid Id { get; set; }

        [Column("TX_FIRST_NAME")]
        public required string FirstName { get; set; }

        [Column("TX_LAST_NAME")]
        public required string LastName { get; set; }

        [Column("TX_PARTICIPATION")]
        public required int Participation { get; set; }

        [Column("TX_CREATED_AT")]
        public required DateTime CreatedAt { get; set; }
    }
}
