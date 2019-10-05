using System;
namespace RegistrationApp.Models
{
    public class User
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        public User() { }

        public User(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }
    }
}
