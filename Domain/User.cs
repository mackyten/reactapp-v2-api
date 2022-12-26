using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        [Key]   
        [Required]
        public string email{ get; set; }

        [Required]
        public string password{ get; set; }

        [Required]
        public string role { get; set; }

        [Required]
        public string firstname { get; set; }

        [Required]
        public string surname { get; set; }

    }
}
