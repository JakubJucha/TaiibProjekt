using ProjektTaiib.DAL.Encje;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Encje
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id_user { get; set; }
        [Required]
        [MaxLength(25)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.[a-z])(?=.[A-Z])(?=.*\d).{8,}$",
         ErrorMessage = "Password must be at least 8 characters long and contain at least one lowercase letter, one uppercase letter, and one digit.")]
        public string Password { get; set; }
        [Required]
        public bool Moderator { get; set; }
        public virtual ICollection<Ticket>? Tickets { get; set; }
    }
}
