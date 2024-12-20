using StoreLibrary.Models;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace BeautyStore.Pages
{
    /// <summary>
    /// Логика взаимодействия для ShopPage.xaml
    /// </summary>
    public partial class ShopPage : Page
    {
        public ShopPage()
        {
            InitializeComponent();
            var currentUser = Application.Current.Properties["CurrentUser"] as User;
            UpdateLoginButton(currentUser);

        }
        private void UpdateLoginButton(User? currentUser)
        {
            if (currentUser == null)
                LoginButton.Content = "Войти";
            else
                LoginButton.Content = "Выйти";
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var currentUser = Application.Current.Properties["CurrentUser"] as User;

            if (currentUser == null)
                NavigationService.Navigate(new AuthorizationPage());
            else
                Application.Current.Properties["CurrentUser"] = null;
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void OrderPanelButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new OrderPanelPage());
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
