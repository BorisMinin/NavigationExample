using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Core;

namespace NavigationExample_v1._0
{
    public sealed partial class MainPage : Page
    {
        #region Переменные и коллекции 
        string entered_login; // Переменная для хранения введенного пользователем значения login 
        string entered_password; // Переменная для хранения введенного пользователем значения password
        #endregion

        public MainPage()
        {
            this.InitializeComponent();
        }

        #region Функции проверки введенных значений с сохраненными 
        /// <summary>
        /// Функция сравнивает значение введенное пользователем(login) с сохраненным
        /// </summary>
        /// <param name="entered">введенное значение</param>
        /// <param name="saved">сохраненное значение</param>
        /// <returns>
        /// true - если совпадает
        /// falce - если не совпадает
        /// </returns>
        bool IsLoginTrue(string entered, string saved)
        {
            if (entered == saved)
                return true;
            else return false;
        }
        /// <summary>
        /// Функция сравнивает значение введенное пользователем(password) с сохраненным
        /// </summary>
        /// <param name="entered">введенное значение</param>
        /// <param name="saved">сохраненное значение</param>
        /// <returns>
        /// true - если совпадает
        /// falce - если не совпадает
        /// </returns>
        bool IsPasswordTrue(string entered, string saved)
        {
            if (entered == saved) 
                return true;
            else return false;
        }
        /// <summary>
        /// Проверяет заполнены ли поля txtLogin и txtPassword 
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        /// <returns>
        /// true - если обе строки заполнены
        /// false - если обе строки пусты
        /// </returns>
        bool IsLoginAndPasswordFilled(string login, string password)
        {
            bool IsLoginFilled = !(string.IsNullOrEmpty(login)); // проверяет не заполнена ли строка логина
            bool IsPasswordFilled = !(string.IsNullOrEmpty(password)); // проверяет не заполнена ли строка пароля
            bool result = IsLoginFilled & IsPasswordFilled; // проверяет не заполнены ли строки логин и пароль
            return result; // возвращает ответ(необходим для отладки)
        }
        #endregion

        #region Обработчики событий
        /// <summary>
        /// Обработчик событий для поля Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnEnter.IsEnabled = IsLoginAndPasswordFilled(txtLogin.Text, txtPassword.Password); // Кнопка Enter будет доступна, если поля логин и пароль не будут заполнены
        }
        /// <summary>
        /// Обработчик событий для поля Password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            btnEnter.IsEnabled = IsLoginAndPasswordFilled(txtLogin.Text, txtPassword.Password); // Кнопка Enter будет доступна, если поля логин и пароль не будут заполнены
        }

        /// <summary>
        /// Обработчик событий для кнопки Enter, в котором будет возвращаться текст для случая, если данные верны и для случая, если данные не верны
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var list = UserRepository.AllUsers(); // инициализация класса UserRepository

            entered_login = txtLogin.Text; //переменная хранит в себе значение полученное из поля логина
            entered_password = txtPassword.Password; //переменная хранит в себе значение полученное из поля пароля

            /// <summary>
            /// осуществляет навигацию на UserPage в случае если данные введены корректно, а в случае если данные введены некорректно, осуществляет навигацию на RegistrationView
            /// </summary>
            foreach (User user in list)
            {
                if (user.Login == entered_login & user.Password == entered_password) // Если введенные логин и пароль, совпадают с сохраненными, то осуществляется навигация на страницу UserPage 
                {
                    txtLogin.Text = ""; 
                    txtPassword.Password = "";
                    Frame.Navigate(typeof(UserPage), user.Login); // Осуществляется навигация на страницу UserPage
                }
                else // В противном случае осуществляется навигация на страницу RegistrationView
                {
                    txtLogin.Text = "";
                    txtPassword.Password = "";
                    Frame.Navigate(typeof(RegistrationView)); // Осуществляется навигация на страницу RegistrationView
                }
            }
        }
        #endregion
    }
}