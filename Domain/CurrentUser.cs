using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class CurrentUser
    {

        public bool authenticated { get; set; }
  
        public string email { get; set; }

        public string role { get; set; }

        public string firstname { get; set; }

        public string surname { get; set; }

        public string JWT { get; set; }
        
    }
}
