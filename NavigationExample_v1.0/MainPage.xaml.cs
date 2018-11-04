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
// Объявим переменные 
// Зададим значения для сохраненных данных(saved_login, saved_password)
// ----------С переменными закончено----------
// Напишем функции, которые будут сверять введенные значения с сохраненными
// Создадим обработчики событий
// Создадим функцию которая проверяет заполнены ли поля txtLogin и txtPassword
// Добавим обработчки событий для кнопки Enter

namespace NavigationExample_v1._0
{
    public sealed partial class MainPage : Page
    {
        #region Переменные
        string user1Login = "user1"; // Сохраненный логин для user1
        string user1Password = "pass1"; // Сохраненный пароль для user1

        string user2Login = "user2"; // Переменная хранит в себе значение, с которым будет сравниваться введеный пользователем логин
        string user2Password = "pass2"; // Переменная хранит в себе значение, с которым будет сравниваться введеный пользователем пароль

        string entered_login; // Переменная для хранения введенного пользователем значения login 
        string entered_password; // Переменная для хранения введенного пользователем значения password
        #endregion

        public MainPage()
        {
            this.InitializeComponent();
        }

        #region Функции проверки введенных значений с сохраненными //позже надо вынести всё в отдельную функцию
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
            btnEnter.IsEnabled = IsLoginAndPasswordFilled(txtLogin.Text, txtPassword.Password);
        }
        /// <summary>
        /// Обработчик событий для поля Password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            btnEnter.IsEnabled = IsLoginAndPasswordFilled(txtLogin.Text, txtPassword.Password);
        }

        /// <summary>
        /// Обработчик событий для кнопки Enter, в котором будет возвращаться текст для случая, если данные верны и для случая, если данные не верны
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            entered_login = txtLogin.Text; //переменная хранит в себе значение полученное из поля логина
            entered_password = txtPassword.Password; //переменная хранит в себе значение полученное из поля пароля

            bool isLoginOfUser1True = IsLoginTrue(entered_login, user1Login);
            bool isPasswordOfUser1True = IsPasswordTrue(entered_password, user1Password);
            bool isLoginOfUser2True = IsLoginTrue(entered_login, user2Login);
            bool isPasswordOfUser2True = IsPasswordTrue(entered_password, user2Password);

            if (isLoginOfUser1True && isPasswordOfUser1True) // условие, если логин и пароль верны, ТО совершается переход на страницу User1Page
                Frame.Navigate(typeof(User1Page), txtLogin.Text);
            else // в противном случае красный цвет и сообщение о том что введено неверное значение
            {
                SolidColorBrush txtColorTrue = new SolidColorBrush(Windows.UI.Colors.Red);
                txtInfo.Background = txtColorTrue;
                txtInfo.Text = "entered wrong values";
            }
        }
        #endregion
        //private void backButton_Tapped(object sender, BackRequestedEventArgs e)
        //{
        //    if (Frame.CanGoBack) Frame.GoBack();
        //}

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    base.OnNavigatedFrom(e);
        //    var currentView = SystemNavigationManager.GetForCurrentView();
        //    currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        //    currentView.BackRequested -= backButton_Tapped;
        //}
    }
}