using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.DAL.Entity
{
    public class Secretary
    {

        [Required]
        [Key]
        public int patientId { get; set; }
        [Required(ErrorMessage ="Name is required ")]
        [MaxLength(50,ErrorMessage ="max lenth is 50")]
        public string PatientName { get; set; }
        public DateTime Birthdate { get; set; }
        public string BloodType { get; set; }

    }
}
