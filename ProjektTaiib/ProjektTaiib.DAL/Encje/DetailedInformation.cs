using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektTaiib.DAL.Encje
{
    public class DetailedInformation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id_information { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        public string Surname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\+48\d{9}$",
         ErrorMessage = "Wrong phone number!")]
        public string Phone { get; set; }

        [Required]
        [MaxLength(10)]
        public string Payment { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(10)]
        public string Zip_code { get; set; }

        [Required]
        [MaxLength(50)]
        public string Street { get; set; }

        [Required]
        public int House_number { get; set; }

        public int? Local_number { get; set; }

        [MaxLength(500)]
        public string? Additional_information { get; set; }
    }
}
