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
using System.Runtime.CompilerServices;

namespace ApartmanManager
{

    public partial class MainWindow : Window
    {

        public ObservableCollection<Room> roomsOfHouse = new ObservableCollection<Room>();
        public ObservableCollection<Visibility> visibilities = new ObservableCollection<Visibility>();

        public MainWindow()
        {       
            InitializeComponent();          
            lvHouses.ItemsSource = InstanceManager.houseCollection;
            lvRooms.ItemsSource = roomsOfHouse;

            MainCalendar_DisplayModeChanged(null, null);

            CalendarManager.InitDays();

            lbl1a.DataContext = CalendarManager.days[0];
            lbl2a.DataContext = CalendarManager.days[1];
            lbl3a.DataContext = CalendarManager.days[2];
            lbl4a.DataContext = CalendarManager.days[3];
            lbl5a.DataContext = CalendarManager.days[4];
            lbl6a.DataContext = CalendarManager.days[5];
            lbl7a.DataContext = CalendarManager.days[6];
            lbl8a.DataContext = CalendarManager.days[7];
            lbl9a.DataContext = CalendarManager.days[8];
            lbl10a.DataContext = CalendarManager.days[9];
            lbl11a.DataContext = CalendarManager.days[10];
            lbl12a.DataContext = CalendarManager.days[11];
            lbl13a.DataContext = CalendarManager.days[12];
            lbl14a.DataContext = CalendarManager.days[13];
            lbl15a.DataContext = CalendarManager.days[14];
            lbl16a.DataContext = CalendarManager.days[15];
            lbl17a.DataContext = CalendarManager.days[16];
            lbl18a.DataContext = CalendarManager.days[17];
            lbl19a.DataContext = CalendarManager.days[18];
            lbl20a.DataContext = CalendarManager.days[19];
            lbl21a.DataContext = CalendarManager.days[20];
            lbl22a.DataContext = CalendarManager.days[21];
            lbl23a.DataContext = CalendarManager.days[22];
            lbl24a.DataContext = CalendarManager.days[23];
            lbl25a.DataContext = CalendarManager.days[24];
            lbl26a.DataContext = CalendarManager.days[25];
            lbl27a.DataContext = CalendarManager.days[26];
            lbl28a.DataContext = CalendarManager.days[27];
            lbl29a.DataContext = CalendarManager.days[28];
            lbl30a.DataContext = CalendarManager.days[29];
            lbl31a.DataContext = CalendarManager.days[30];


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
            CalendarManager.CleanOwners();

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

        private void lvRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var firstDayOfMonth = new DateTime(MainCalendar.DisplayDate.Year, MainCalendar.DisplayDate.Month, 1);
            int dayNr = DateTime.DaysInMonth(MainCalendar.DisplayDate.Year, MainCalendar.DisplayDate.Month);
            CalendarManager.UpdateDays(firstDayOfMonth, dayNr, (Room)lvRooms.SelectedItem);

            int daysCnt = DateTime.DaysInMonth(MainCalendar.DisplayDate.Year, MainCalendar.DisplayDate.Month);
            switch (daysCnt)
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
    }
}
