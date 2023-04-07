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
    [Table("Sponsors")]
    public class Sponsor
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id_sponsor { get; set; }
        [Required]
        [MaxLength(50)]
        public string Sponsor_name { get; set; }
        public List<Event>? Events { get; set; }
    }
}
