using System;

namespace PasswordKeeper
{
    class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsActive { get; set; }
    }
}
