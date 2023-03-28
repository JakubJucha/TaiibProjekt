using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Encje
{
    [Table("Events")]
    public class Event
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id_event { get; set; }
        [Required]
        [MaxLength(80)]
        public string Event_name { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Location { get; set; }
        [MaxLength(500)]
        public string? Description { get; set; }

        [Required]
        public string Category { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Sponsor> Sponsors { get; set; }

    }
}
