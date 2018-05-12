using System;
using System.Collections.Generic;
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

using ApartmanManagerLib;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace ApartmanManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml FF0CFF00"
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Room> roomsOfHouse = new ObservableCollection<Room>();

        public MainWindow()
        {       
            InitializeComponent();          
            lvHouses.ItemsSource = InstanceManager.houseCollection;
            lvRooms.ItemsSource = roomsOfHouse;

            MainCalendar_DisplayModeChanged(null, null);


        }


        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            ProgramFlow.IsLoggedIn = true;
            ProgramFlow.StartUp();

            if (ProgramFlow.IsLoggedIn == true)
            {
                BtnHouses.IsEnabled = true;
                BtnReceipts.IsEnabled = true;
                BtnSettings.IsEnabled = true;
                BtnRooms.IsEnabled = true;
                BtnGuests.IsEnabled = true;


                AppStateTxt.Text = "LoggedIn";
                AppStateTxt.Background = Brushes.Green;
            }

        }

        private void BtnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow SettingsWin = new SettingsWindow();
            SettingsWin.Owner = this;
            SettingsWin.ShowDialog();

        }

        private void BtnHouses_Click(object sender, RoutedEventArgs e)
        {
            HouseWindow HouseWin = new HouseWindow();
            HouseWin.Owner = this;
            HouseWin.ShowDialog();
        }

        void AppClosing(object sender, CancelEventArgs e)
        {
            ProgramFlow.ExitSave();
        }

        private void BtnRooms_Click(object sender, RoutedEventArgs e)
        {
            RoomWindow RoomWin = new RoomWindow();
            RoomWin.Owner = this;
            RoomWin.ShowDialog();
        }

        private void BtnGuests_Click(object sender, RoutedEventArgs e)
        {
            GuestWindow GuestWin = new GuestWindow();
            GuestWin.Owner = this;
            GuestWin.ShowDialog();
        }

        private void MainCalendar_DisplayModeChanged(object sender, CalendarModeChangedEventArgs e)
        {
            if (CalendarGrid != null)
            {
                var firstDayOfMonth = new DateTime(MainCalendar.DisplayDate.Year, MainCalendar.DisplayDate.Month, 1);
                if ((int)firstDayOfMonth.DayOfWeek != 0)
                {
                    CalendarGrid.FirstColumn = (int)firstDayOfMonth.DayOfWeek - 1;
                }
                else
                {
                    CalendarGrid.FirstColumn = 6;
                }

                int days = DateTime.DaysInMonth(MainCalendar.DisplayDate.Year, MainCalendar.DisplayDate.Month);
                switch (days)
                {
                    case 28:
                        d29.Visibility = Visibility.Hidden;
                        d30.Visibility = Visibility.Hidden;
                        d31.Visibility = Visibility.Hidden;
                        break;

                    case 29:
                        d29.Visibility = Visibility.Visible;
                        d30.Visibility = Visibility.Hidden;
                        d31.Visibility = Visibility.Hidden;
                        break;

                    case 30:
                        d29.Visibility = Visibility.Visible;
                        d30.Visibility = Visibility.Visible;
                        d31.Visibility = Visibility.Hidden;
                        break;

                    default:
                        d29.Visibility = Visibility.Visible;
                        d30.Visibility = Visibility.Visible;
                        d31.Visibility = Visibility.Visible;
                        break;
                }

            }

            MainCalendar.DisplayMode = CalendarMode.Year;
        }

        private void lvHouses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            roomsOfHouse.Clear();

            foreach (Room r in InstanceManager.roomCollection)
            {
                if ((House)lvHouses.SelectedItem == r.ItsHouse)
                {
                    roomsOfHouse.Add(r);
                }
            }
        }
    }
}
