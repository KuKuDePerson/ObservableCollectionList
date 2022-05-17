using System.Windows;

namespace BasicRegionNavigation.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pwd = pwdBox.Password;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PassWordWindow passWordWindow = new PassWordWindow();
            passWordWindow.Show();
        }
    }
}
