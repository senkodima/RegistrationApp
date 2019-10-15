using System.Collections.Generic;
using System.Threading.Tasks;
using RegistrationApp.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;

namespace RegistrationApp.Data
{
    public class UserDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public UserDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<User>().Wait();
            _database.CreateTableAsync<UserTask>().Wait();
        }

        public Task UpdateUserAsync(User user)
        {
            return _database.UpdateWithChildrenAsync(user);
        }


        public Task<List<User>> GetAllUsersAsync()
        {
            return _database.Table<User>().ToListAsync();
        }
        public Task<List<UserTask>> GetAllUserTasksAsync()
        {
            return _database.Table<UserTask>().ToListAsync();
        }


        public Task<User> GetUserAsync(int id)
        {
            return _database.Table<User>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }
        public Task<UserTask> GetUserTaskAsync(int id)
        {
            return _database.Table<UserTask>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }


        public Task<int> SaveUserAsync(User user)
        {
            if (user.ID != 0)
            {
                return _database.UpdateAsync(user);
            }
            else
            {
                return _database.InsertAsync(user);
            }
        }
        public Task<int> SaveUserTaskAsync(UserTask userTask)
        {
            if (userTask.ID != 0)
            {
                return _database.UpdateAsync(userTask);
            }
            else
            {
                return _database.InsertAsync(userTask);
            }
        }


        public Task<int> DeleteUserAsync(User user)
        {
            return _database.DeleteAsync(user);
        }
        public Task<int> DeleteUserTaskAsync(UserTask userTask)
        {
            return _database.DeleteAsync(userTask);
        }

    }
}
