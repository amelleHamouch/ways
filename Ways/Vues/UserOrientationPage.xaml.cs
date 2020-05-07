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

namespace Ways.Vues
{
    /// <summary>
    /// Logique d'interaction pour UserOrientationPage.xaml
    /// </summary>
    public partial class UserOrientationPage : Page
    {
        int playerScore; 
        public UserOrientationPage(int score)
        {
            playerScore = score;
            InitializeComponent();
            if(score < 2)
            {
               
                OrientationLabel.Content = "Dev";
                Descriptiontxt.Text = "Le développeur informatique est spécialisé en conception et développement d’applications pour les différents supports de l’entreprise (PC, smartphone / tablette, web). Il conçoit et développe celles-ci au sein d’une équipe projet à partir du cahier des charges clients qu’il analyse et formalise pour proposer les solutions logicielles adéquates. Il exerce également un rôle de facilitateur des applications informatiques auprès des utilisateurs.\nLes Débouchés dans cette filières sont :\nAnalyste-programmeur\nAnalyste développementAnalystefonctionnel\nAnalyste réalisateur\nConcepteur-développeur \nDéveloppeur d'applications\n Développeur informatique";
            }
            else if (score > -2)
            {
                OrientationLabel.Content = "Réseau";
                Descriptiontxt.Text = "Le technicien systèmes et réseaux est responsable du bon fonctionnement au quotidien des éléments matériels et logiciels composant le réseau de l’entreprise. Il installe et configure tout nouveau matériel ou logiciel réseau et en assure la maintenance de façon curative et préventive. Il a la responsabilité des données de l’entreprise (fichiers, base de données, mails…) hébergées sur ses propres serveurs, tant au niveau des sauvegardes et restaurations que de la gestion des accès et de la sécurité. En opérant une veille technologique dans son environnement métier, il participe à l’évolution et l’optimisation du réseau de l’entreprise et s’adapte à l’évolution du marché et de ses compétences. \n Les débouchés dans cette filières sont : \nTechnicien systèmes et/ou réseaux\nTechnicien informatiques et réseaux\n Technicien réseaux et télécoms\nTechnicien d'exploitation réseaux \nTechnicien d'exploitation réseaux\nAdministrateur systèmes et/ou réseaux\n";
            }
            else
            {
                OrientationLabel.Content = "Dev'Ops";
                Descriptiontxt.Text = " A la frontière entre le profil dev et réseau existe un profil rare , le Dev'Ops . Ces créatures légendaires sont très recherchés par les entreprises ";
            }
        }

        private void mailMe(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new UserMailPage(playerScore));
        }

        private void StartGame(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new QuizzPage(2));
        }
    }
}
