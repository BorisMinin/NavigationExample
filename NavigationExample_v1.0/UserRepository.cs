using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NavigationExample_v1._0
{
    public static class UserRepository
    {
        private static List<User> ListUsers; // Объявляем коллекцию пользователей

        /// <summary>
        /// Конструктор класса UserRepository, хранит в себе значения поьзователей, сохраненных поумолчанию
        /// </summary>
        static UserRepository()
        {
            ListUsers = new List<User> 
            {
                new User { UserID = 1, Login = "user1", Password = "passw1" },
                new User { UserID = 2, Login = "user2", Password = "passw2" },
            };
        }

        public static IList<User> AllUsers() => ListUsers;
        /// <summary>
        /// Метод, позволяет добавлять новых пользователей
        /// </summary>
        /// <param name="user"></param>
        public static void AddUser(User user)
        {
            ListUsers.Add(user);
        }
    }
}