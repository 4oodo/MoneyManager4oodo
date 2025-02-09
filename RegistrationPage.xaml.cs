using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MoneyManager4oodo
{
    public partial class RegistrationPage : Page
    {
        public bool RegistrationSuccess = false;
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Registrate_Button_Click(object sender, RoutedEventArgs e)
        {
            RegistrationSuccess = CheckDataRegistration();
            if (RegistrationSuccess)
            {
                MessageBox.Show("Вы успешно зарегистрировались!");
                NavigationService.GoBack();
            }
            else
            {
                MessageBox.Show("Регистрация провалена!");
            }
        }

        private bool CheckDataRegistration()
        {
            bool emptyField = SurnameTextBox.Text.Equals("") || NameTextBox.Text.Equals("") || 
                              LoginTextBox.Text.Equals("") || PasswordBox.Password.Equals("");
            return !emptyField; 
        }


        private void GoBackTextClickMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}