using SQLite;
using SQLiteNetExtensions.Attributes;

namespace RegistrationApp.Models
{
    [Table("UserTask")]
    public class UserTask
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }

        [ForeignKey(typeof(User))]
        public int UserID { get; set; }

        [ManyToOne]
        public User User { get; set; }

        public UserTask() { }

        #region FOR DEBUG
        public override string ToString()
        {
            return $"\n\t ID: {ID}" +
                   $"\n\t Description: {Description}" +
                   $"\n\t UserID: {UserID}";
        }
        #endregion
    }
}
