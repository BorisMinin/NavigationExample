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
        public MainPage()
        {
            this.InitializeComponent();
        }

        #region Функции проверки введенных значений с сохраненными 
        /// <summary>
        /// Функция сравнивает введенное значение с сохраненным для поля txtLogin
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
        /// Функция сравнивает введенное значение с сохраненным для поля txtPassword   
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
        /// Проверяет на заполнение поля txtLogin и txtPassword 
        /// </summary>
        /// <param name="login">логин</param>
        /// <param name="password">пароль</param>
        /// <returns>
        /// true - если обе строки заполнены
        /// false - если обе строки пусты
        /// </returns>
        bool IsLoginAndPasswordFilled(string login, string password)
        {
            bool IsLoginFilled = !(string.IsNullOrEmpty(login)); // проверка строки txtLogin
            bool IsPasswordFilled = !(string.IsNullOrEmpty(password)); // проверка строки txtPassword
            bool result = IsLoginFilled & IsPasswordFilled; // проверка строк txtLogin и txtPassword
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
            btnEnter.IsEnabled = IsLoginAndPasswordFilled(txtLogin.Text, txtPassword.Password); // Доступность кнопки brnEnter в случае заполненности полей txtLogint и txtPassword 
        }
        /// <summary>
        /// Обработчик событий для поля Password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            btnEnter.IsEnabled = IsLoginAndPasswordFilled(txtLogin.Text, txtPassword.Password); // Доступность кнопки brnEnter в случае заполненности полей txtLogint и txtPassword
        }

        /// <summary>
        /// Проверка логина и пароля, а так же навигация
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            User user = IsUserRegistered(txtLogin.Text, txtPassword.Password);
            Navigation(user);
        }

        /// <summary>
        /// Сравнение введенного логина и сохраненного
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>
        /// user-если совпадает
        /// null-если не совпадает
        /// </returns>
        private User IsUserRegistered(string login, string password)
        {
            foreach (User user in UserRepository.AllUsers())
            {
                if (user.Login == login & user.Password == password)
                    return user;
            }
            return null;
        }
        /// <summary>
        /// Навигация, если метод IsUserRegistered возвращает null, то навигация на RegistrationView, иначе навигация на UserPage
        /// </summary>
        /// <param name="user"></param>
        private void Navigation(User user)
        {
            if (user == null) Frame.Navigate(typeof(RegistrationView));
            else Frame.Navigate(typeof(UserPage), user.Login);
        }
    }
    #endregion

}