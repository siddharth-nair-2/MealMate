using Firebase.Database;
using Firebase.Database.Query;
using MealMate.Helpers;
using MealMate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealMate.Services
{
    public class UserService
    {
        FirebaseClient client;

        public UserService()
        {
            client = new FirebaseClient(Constants.URL);
        }

        public async Task<bool> DoesUserExist(string username)
        {
            var user = (await client.Child("Users").OnceAsync<User>()).Where(u => u.Object.Username == username).FirstOrDefault();

            return (user != null);
        }

        public async Task<bool> RegisterUser(string username, string password)
        {
            if (await DoesUserExist(username) == false)
            {
                await client.Child("Users").PostAsync(new User()
                {
                    Username = username,
                    Password = password
                });
                return true;
            }

            return false;
        }

        public async Task<bool> LoginUser(string username, string password)
        {
            var user = (await client.Child("Users")
                .OnceAsync<User>()).Where(u => u.Object.Username == username)
                .Where(u => u.Object.Password == password)
                .FirstOrDefault();

            return (user != null);
        }
    }
}
