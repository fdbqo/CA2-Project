using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

using CA2.Players;
using CA2.Teams;

namespace CA2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            GetData();
            
        }

        public void GetData()
        {
            Team t1 = new Team() { Name = "France" };
            Team t2 = new Team() { Name = "Italy" };
            Team t3 = new Team() { Name = "Spain" };

            ObservableCollection<Team> teams = new ObservableCollection<Team>() { t1, t2, t3 };

            TeamsDisplay.ItemsSource = teams;
            TeamsDisplay.DisplayMemberPath = "Name";
        }


        /*
        public void changeStar()
        {
            string imagePath = "pack://application:,,,/CA2;component/starsolid.png";


            try
            {
                BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
                star1.Source = bitmapImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading image: {ex.Message}");
            }
        }
        */
    }
}
