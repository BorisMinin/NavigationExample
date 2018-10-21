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
// Объявим переменные 
// Зададим значения для сохраненных данных(saved_login, saved_password)
// ----------С переменными закончено----------
// Создадим обработчики событий

namespace NavigationExample_v1._0
{
    public sealed partial class MainPage : Page
    {
        #region Переменные
        string saved_login = "Борис";
        string saved_password = "1111";
        string entered_login;
        string entered_password;
        #endregion

        public MainPage()
        {
            this.InitializeComponent();
        }

        #region Обработчики событий
        /// <summary>
        /// Обработчик событий для поля Login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtLogin_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        /// <summary>
        /// Обработчик событий для поля Password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}