using System;
using System.Collections.Generic;

namespace PasswordKeeper
{
    public class PasswordModel
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string PasswordBullets { get { return "●●●●●●"; } }
        public string Key { get; set; }
        public string Url { get; set; }
        public string Notes { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
