using System;
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
    /// Logique d'interaction pour AdminEmailSettingsPage.xaml
    /// </summary>
    public partial class AdminEmailSettingsPage : Page
    {
        public AdminEmailSettingsPage()
        {
            InitializeComponent();
            IDictionary<string, string> mailSettings = Mail.getMailSettings();
            adminLogin.Text =           mailSettings["mailAddress"];
            adminPassBox.Password =     mailSettings["mailPassword"];
            sujetBox.Text =             mailSettings["sujet"];
            corpsBox.Text =             mailSettings["corps"];
            promoSujetBox.Text =        mailSettings["promoSujet"];
            promoMailBox.Text =         mailSettings["promoMail"];
            
        }

        private void saveEmailSettings(object sender, RoutedEventArgs e)
        {
            Mail.saveMailSettings(adminLogin.Text, adminPassBox.Password, sujetBox.Text, corpsBox.Text, promoSujetBox.Text, promoMailBox.Text);
        }
    }
}
