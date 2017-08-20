using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Adre.Controls.StartList.TeamVSTeam
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : UserControl
    {
        public Editor()
        {
            InitializeComponent();
        }

        private void SelectedAthleteAChanged(object sender, RoutedEventArgs e)
        {
            IItemViewModel db = (IItemViewModel)DataContext;
            ListView x = (ListView)sender;

            if (x.SelectedItem != null)
            {
                db.SelectedAthleteA.Add((IAthlete)x.SelectedItem);
                db.AthleteListA.Remove((IAthlete)x.SelectedItem);
                db.SelectedAthleteA = db.SelectedAthleteA;
            }
        }

        private void DeselectAthleteAChanged(object sender, RoutedEventArgs e)
        {
            IItemViewModel db = (IItemViewModel)DataContext;
            ListView x = (ListView)sender;

            if (x.SelectedItem != null)
            {
                db.AthleteListA.Add((IAthlete)x.SelectedItem);
                db.SelectedAthleteA.Remove((IAthlete)x.SelectedItem);
                db.SelectedAthleteA = db.SelectedAthleteA; 
            }
        }

        private void SelectedReserveAChanged(object sender, RoutedEventArgs e)
        {
            IItemViewModel db = (IItemViewModel)DataContext;
            ListView x = (ListView)sender;

            if (x.SelectedItem != null)
            {
                db.AthleteListA.Remove((IAthlete)x.SelectedItem);
            }
        }

        private void DeselectReserveAChanged(object sender, RoutedEventArgs e)
        {
            IItemViewModel db = (IItemViewModel)DataContext;
            ListView x = (ListView)sender;

            if (x.SelectedItem != null)
            {
                db.AthleteListA.Add((IAthlete)x.SelectedItem);
            }
        }

        private void SelectedAthleteBChanged(object sender, RoutedEventArgs e)
        {
            IItemViewModel db = (IItemViewModel)DataContext;
            ListView x = (ListView)sender;

            if (x.SelectedItem != null)
            {
                db.SelectedAthleteB.Add((IAthlete)x.SelectedItem);
                db.AthleteListB.Remove((IAthlete)x.SelectedItem);
                db.SelectedAthleteB = db.SelectedAthleteB;
            }

        }

        private void DeselectAthleteBChanged(object sender, RoutedEventArgs e)
        {
            IItemViewModel db = (IItemViewModel)DataContext;
            ListView x = (ListView)sender;

            if (x.SelectedItem != null)
            {
                db.AthleteListB.Add((IAthlete)x.SelectedItem);
                db.SelectedAthleteB.Remove((IAthlete)x.SelectedItem);
                db.SelectedAthleteB = db.SelectedAthleteB;
            }
        }

        private void SelectedReserveBChanged(object sender, RoutedEventArgs e)
        {
            IItemViewModel db = (IItemViewModel)DataContext;
            ListView x = (ListView)sender;

            if (x.SelectedItem != null)
            {
                db.AthleteListB.Remove((IAthlete)x.SelectedItem);
            }

        }

        private void DeselectReserveBChanged(object sender, RoutedEventArgs e)
        {
            IItemViewModel db = (IItemViewModel)DataContext;
            ListView x = (ListView)sender;

            if (x.SelectedItem != null)
            {
                db.AthleteListB.Add((IAthlete)x.SelectedItem);
            }
        }
    }
}
