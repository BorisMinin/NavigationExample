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
    public sealed partial class UserPage : Page
    {
        /// <summary>
        /// Реализованна возможность возврата на предыдущую страницу посредством кнопки "назад" в верхней левой части экрана
        /// </summary>
        public UserPage()
        {
            var currentView = SystemNavigationManager.GetForCurrentView();
            currentView.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible; // кнопка видима
            currentView.BackRequested += backButton_Tapped; // происходит подписка на событие
            this.InitializeComponent();
        }
        /// <summary>
        /// Метод, в котором прописывается событие, которое произойдет когда кнопка будет нажата
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backButton_Tapped(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack) Frame.GoBack();
        }
        /// <summary>
        /// Метод позволяет поприветствовать того или иного пользователя, в зависимости от того, под каким ником, пользователь вошел в "систему"
        /// </summary>
        /// <param name="e">
        /// Если user1, то "Welcome, user1"
        /// Если user2, то "Welcome, user2"
        /// </param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (e.Parameter.ToString() == "user1") // Если пользователь вошел в систему под ником user1, то его приветствуют как user1
                txtBlockWelcome.Text = ($"Welcome, {e.Parameter.ToString()}");
            else if (e.Parameter.ToString() == "user2") // Если пользователь вошел в систему под ником user2, то его приветствуют как user2
                txtBlockWelcome.Text = ($"Welcome, {e.Parameter.ToString()}");
            else 
                txtBlockWelcome.Text = ($"Welcome, { e.Parameter.ToString()}"); // Если новый пользователь, то приветствуют как нового пользователя
        }
    }
}