using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Entity
{
    public class Doctor
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50,ErrorMessage ="max length is 50 char")]
        [MinLength(5, ErrorMessage = "min length is 5 char")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }

    }
}
