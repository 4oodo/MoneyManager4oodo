using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MoneyManager4oodo
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        Window loginWindow;
        
        Datebase datebase = new Datebase();
        public LoginPage(Window loginWindow)
        {
            InitializeComponent();
            this.loginWindow = loginWindow;
        }

        
        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {
            if(Authorize())
            {
                ManagerWindow managerWindow = new ManagerWindow();
                managerWindow.Show();
                loginWindow.Close();   
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
            
        }

        private bool Authorize()
        {
            var login = LoginTextBox;
            var password = PasswordTextBox;
            if (login.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Неправильный логин или пароль!");
            }
            else if (CheckData(login, password))
            {
                return true;
            }

            return false; 
        }

        private bool CheckData(TextBox login, PasswordBox password)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string query =
                $"SELECT UserID, Name, Surname FROM users WHERE login = '{login}' AND password = '{password}'";
            try
            {
                SqlCommand command = new SqlCommand(query, datebase.GetConnection());

                adapter.SelectCommand = command;
                adapter.Fill(table);

                if (table.Rows.Count == 1)
                {
                    MessageBox.Show($"Добро пожаловать, {table.Rows[0].Field<string>("Name")}");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    

        private void RegistrateTextClickMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegistrationPage());
        }
    }
}
