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
    [Table("Tickets")]
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id_ticket { get; set; }
        [Required]
        public int Id_event { get; set; }
        [ForeignKey(nameof(Id_event))]
        [Required]
        public virtual Event Event { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public double Price { get; set; }
        public bool? Premium { get; set; }


    }
}
