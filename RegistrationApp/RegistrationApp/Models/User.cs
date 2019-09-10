using System.Collections.Generic;

namespace RegistrationApp.Models
{
    public class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public List<string> TaskList { get; set; }
    }
}
