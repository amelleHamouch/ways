﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Ways.Classes;


namespace Ways.Vues
{
    /// <summary>
    /// Logique d'interaction pour UserListPage.xaml
    /// </summary>
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            User user = new User();
            UserList.ItemsSource = user.GetAllUsers();
            List<User> items = new List<User>();
            InitializeComponent();

        }

    
    }
}
