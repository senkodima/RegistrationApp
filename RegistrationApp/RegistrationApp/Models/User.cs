using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace RegistrationApp.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }

        [OneToMany]
        public List<UserTask> Tasks { get; set; }

        public User() { }

        public User(string Email, string FirstName, string LastName, string Password, string Phone)
        {
            this.Email = Email;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Password = Password;
            this.Phone = Phone;
        }

        public User(string Email, string Password)
        {
            this.Email = Email;
            this.Password = Password;
        }

        #region FOR DEBUG
        public override string ToString()
        {
            return $"\n   ID:       {ID}" +
                   $"\n   Email:    {Email}" +
                   $"\n   FirstName:{FirstName}" +
                   $"\n   LastName: {LastName}" +
                   $"\n   Password: {Password}" +
                   $"\n   Phone:    {Phone}";
        }
        #endregion
    }
}
