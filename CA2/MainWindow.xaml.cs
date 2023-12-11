using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
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
    /// 
    /// Extra notes : 
    /// Because players is a list, it's not updated as automatically as it should be 
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Team> teams = new ObservableCollection<Team>();
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
            // teams created

            teams = new ObservableCollection<Team>() { t1, t2, t3 };
            // added to the collection
           

            

            //French players
            Player p1 = new Player() { Name = "Marie", ResultRecord = "WWDDL" };
            Player p2 = new Player() { Name = "Claude", ResultRecord = "DDDLW" };
            Player p3 = new Player() { Name = "Antoine", ResultRecord = "LWDLW" };

            //Italian players
            Player p4 = new Player() { Name = "Marco", ResultRecord = "WWDLL" };
            Player p5 = new Player() { Name = "Giovanni", ResultRecord = "LLLLD" };
            Player p6 = new Player() { Name = "Valentina", ResultRecord = "DLWWW" };

            //Spanish players
            Player p7 = new Player() { Name = "Maria", ResultRecord = "WWWWW" };
            Player p8 = new Player() { Name = "Jose", ResultRecord = "LLLLL" };
            Player p9 = new Player() { Name = "Pablo", ResultRecord = "DDDDD" };
            // players name and results definied

            t1.Players = new List<Player> { p1, p2, p3 };
            t2.Players = new List<Player> { p4, p5, p6 };
            t3.Players = new List<Player> { p7, p8, p9 };
            // players added to the teams

            ObservableCollection<Team> sortedTeams = new ObservableCollection<Team>(teams.OrderByDescending(t => t.totalPoints));
            // teams are sorted based on points

            TeamsDisplay.ItemsSource = sortedTeams;
            // and teams are then added to the listbox

        }

        private void TeamsDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            PlayersDisplay.Items.Clear();

            var selectedTeam = TeamsDisplay.SelectedItem as Team;

            if (selectedTeam != null)
            {
                foreach (Player player in selectedTeam.Players)
                {
                    PlayersDisplay.Items.Add(player);
                    
                }

                // displays all players within a team, when that team is selected

                
            }

           
            
        }

   
        private void PlayersDisplay_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedPlayer = PlayersDisplay.SelectedItem as Player;

            if (selectedPlayer != null)
            {
                changeStar(selectedPlayer);
            }
            // calls the change star method whenever a new player is selected to make sure it is up to date
            
        }

        public void changeStar(Player player)
        {
            var check = player.ptsTotal;
            string imagePath = "pack://application:,,,/CA2;component/starsolid.png";
            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePath, UriKind.Absolute));

            string imagePath2 = "pack://application:,,,/CA2;component/staroutline.png";
            BitmapImage bitmapImage2 = new BitmapImage(new Uri(imagePath2, UriKind.Absolute));
            // binds the image to the bitmap 


            star1.Source = bitmapImage2;
            star2.Source = bitmapImage2;
            star3.Source = bitmapImage2;
            // sets the default images to the blank one

            switch (check)
            {
                case var _ when check >= 1 && check <= 5:
                    try
                    {              
                        star1.Source = bitmapImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}");
                    }
                    break;

                case var _ when check >= 6 && check <= 10:
                    try
                    {         
                        star1.Source = bitmapImage;
                        star2.Source = bitmapImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}");
                    }
                    break;

                case var _ when check >= 11:
                    try
                    {
                        star1.Source = bitmapImage;
                        star2.Source = bitmapImage;
                        star3.Source = bitmapImage;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}");
                    }
                    break;

                // this switch statement checks the points of the players, then changes the image of the relevant stars 
            }



            

           
        }


        private void WinButton(object sender, RoutedEventArgs e) // these 3 methods update the player's result record
        {
            const char RESULT = 'W';

            var selectedPlayer = PlayersDisplay.SelectedItem as Player;
            char[] results = selectedPlayer.ResultRecord.ToCharArray();
            
            if (results.Length > 0)
            {
                char[] resultsUpdated = results.Skip(1).ToArray();

                resultsUpdated = resultsUpdated.Concat(new[] { RESULT }).ToArray();

                selectedPlayer.ResultRecord = new string(resultsUpdated);
                // skips first (oldest) record in the string, then adds the new result to it

                UpdateTeamPoints();
            }
            

            
        }

        private void DrawButton(object sender, RoutedEventArgs e) // same as above, but for draw
        {
            const char RESULT = 'D';

            var selectedPlayer = PlayersDisplay.SelectedItem as Player;
            char[] results = selectedPlayer.ResultRecord.ToCharArray();

            if (results.Length > 0)
            {
                char[] resultsUpdated = results.Skip(1).ToArray();

                resultsUpdated = resultsUpdated.Concat(new[] { RESULT }).ToArray();

                selectedPlayer.ResultRecord = new string(resultsUpdated);

                UpdateTeamPoints();
            }


        }

        private void LossButton(object sender, RoutedEventArgs e) // same as above, but for loss
        {
            const char RESULT = 'L';

            var selectedPlayer = PlayersDisplay.SelectedItem as Player;
            char[] results = selectedPlayer.ResultRecord.ToCharArray();

            if (results.Length > 0)
            {
                char[] resultsUpdated = results.Skip(1).ToArray();

                resultsUpdated = resultsUpdated.Concat(new[] { RESULT }).ToArray();

                selectedPlayer.ResultRecord = new string(resultsUpdated);

                UpdateTeamPoints();
            }


        }

        private void UpdateTeamPoints()
        {
            // method is called above whenever an update is made

            foreach (var _team in teams)
            {
                _team._totalPoints = _team.Players.Sum(player => player.ptsTotal);
                // update the points based on the updated player points

            }

      
            // Rebind the sorted teams to the ListBox
            ObservableCollection<Team> sortedTeams = new ObservableCollection<Team>(teams.OrderByDescending(t => t.totalPoints));
            TeamsDisplay.ItemsSource = sortedTeams;
        }


    }
}
