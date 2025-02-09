namespace MoneyManager4oodo
{
    public class User
    {
        private int UserId;
        private string Name;
        private string Surname;
        private string Login;
        private string Password;

        public User(int id, string name, string surname, string login, string password)
        {
            this.UserId = id;
            this.Name = name;
            this.Surname = surname;
            this.Login = login;
            this.Password = password;
        }
        public int getId() {return UserId;}
        public string getName() {return Name;}
        public string getSurname() {return Surname;}
        public string getLogin() {return Login;}
        public string getPassword() {return Password;}
    }
}