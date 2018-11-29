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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Windows.UI.Core;

namespace NavigationExample_v1._0
{
    public sealed partial class RegistrationView : Page
    {
        /// <summary>
        /// Реализованна возможность возврата на предыдущую страницу посредством кнопки "назад" в верхней левой части экрана
        /// </summary>
        public RegistrationView()
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible; // кнопка видима
            currentView.BackRequested += backButton_Tapped; // происходит подписка на событие
            this.InitializeComponent();
        }

        /// <summary>
        /// Обработчик событий для кнопки btnRegistration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            User user = new User(); //Создаем новый экземпляр класса User

            user.Login = txtLoginReg.Text; //Присваиваем экземпляру класса User значения свойства логин из текстового поля
            user.Password = txtPasswReg.Password; //Присваиваем экземпляру класса User значения свойства password из PasswordBox

            UserRepository.AddUser(user); //Добавляем экземпляр класса User в коллекцию Users
            Frame.Navigate(typeof(MainPage)); //Осуществляем навигацию на страницу MainPage
        }

        /// <summary>
        /// Метод, в котором прописывается событие, которое произойдет когда кнопка будет нажата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Tapped(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack) Frame.GoBack(); // Если кнопка нажата, то произойдет навигация на предыдущую страницу
        }



        bool IsLoginAndPasswordFilled(string login, string password)
        {
            bool IsLoginFilled = !(string.IsNullOrEmpty(login)); // проверяет не заполнена ли строка логина
            bool IsPasswordFilled = !(string.IsNullOrEmpty(password)); // проверяет не заполнена ли строка пароля
            bool result = IsLoginFilled & IsPasswordFilled; // проверяет не заполнены ли строки логин и пароль
            return result; // возвращает ответ(необходим для отладки)
        }
        /// <summary>
        /// Обработчик событий для поля txtLoginReg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtLoginReg_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnRegistration.IsEnabled = IsLoginAndPasswordFilled(txtLoginReg.Text, txtPasswReg.Password); // Кнопка Registration будет доступна, если поля логин и пароль не будут заполнены
        }

        /// <summary>
        /// Обработчик событий для поля txtPasswReg
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtPasswReg_PasswordChanged(object sender, RoutedEventArgs e)
        {
            btnRegistration.IsEnabled = IsLoginAndPasswordFilled(txtLoginReg.Text, txtPasswReg.Password); // Кнопка Registration будет доступна, если поля логин и пароль не будут заполнены
        }
    }
}