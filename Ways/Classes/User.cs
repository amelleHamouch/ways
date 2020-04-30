using System;
using System.Collections.Generic;
using System.Text;

namespace Ways.Classes
{
    class User
    {
        private int id;
        private string login;
        private string pass;
        private bool isAdmin;
        private int score;

        public bool IsAdmin { get => isAdmin; set => isAdmin = value; }
        public string Login { get => login; set => login = value; }
        public int Id { get => id; set => id = value; }
        public string Pass { get => pass; set => pass = value; }
        public int Score { get => score; set => score = value; }

        public User(string login, string pass)
        {
            this.login = login;
            this.pass = pass;
        }
        public User()
        {
            
        }


    }

}
