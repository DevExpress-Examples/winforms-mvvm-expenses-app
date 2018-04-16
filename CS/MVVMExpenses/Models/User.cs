using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMExpenses.Models {
    public class User {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
