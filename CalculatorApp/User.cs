namespace CalculatorApp
{
    public class User
    {
        public string username { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int operationsCount { get; set; }

        public User(string username, string email, string password, int operationsCount = 0)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.operationsCount = operationsCount;
        }
    }
}