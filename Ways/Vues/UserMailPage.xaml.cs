using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
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
    /// Logique d'interaction pour UserMailPage.xaml
    /// </summary>
    public partial class UserMailPage : Page
    {
        new User user = new User();
        int scoreUser;
        string userOrientation;
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="orientation">métier</param>
        /// <param name="score">score au test</param>
        /// <param name="userId">Id du candidat</param>
        public UserMailPage(string orientation, int score, int userId)
        {
            InitializeComponent();
            user = User.getUserById(userId);
            scoreUser = score;
            userOrientation = orientation;

        }

        /// <summary>
        /// Envoi des mails
        /// </summary>
        private void sendAllEmails(object sender, RoutedEventArgs e)
        {
            Mail.sendMainMail(UserMailTxt.Text, user.Login, scoreUser.ToString(), userOrientation);
            if (emailBonus1.Text != "") Mail.sendPromoMail(emailBonus1.Text, user.Login, scoreUser.ToString(), userOrientation);
            if (emailBonus2.Text != "") Mail.sendPromoMail(emailBonus2.Text, user.Login, scoreUser.ToString(), userOrientation);
            if (emailBonus3.Text != "") Mail.sendPromoMail(emailBonus3.Text, user.Login, scoreUser.ToString(), userOrientation);
            if (emailBonus4.Text != "") Mail.sendPromoMail(emailBonus4.Text, user.Login, scoreUser.ToString(), userOrientation);
            user.updateUserScore(scoreUser, user.Id);
            this.NavigationService.Navigate(new UserEndPage(user.Id));

        }



    }
}
