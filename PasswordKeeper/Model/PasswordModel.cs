using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordKeeper
{
    public class PasswordModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Url { get; set; }
        public string Notes { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
