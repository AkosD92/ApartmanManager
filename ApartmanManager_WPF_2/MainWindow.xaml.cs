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

namespace ApartmanManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml FF0CFF00"
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            ProgramFlow.StartUp();
            InitializeComponent();


        }


        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            ProgramFlow.IsLoggedIn = true;

            if (ProgramFlow.IsLoggedIn == true)
            {
                BtnHouses.IsEnabled = true;
                BtnReceipts.IsEnabled = true;
                BtnReserve.IsEnabled = true;
                BtnSettings.IsEnabled = true;
                BtnRooms.IsEnabled = true;


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
    }
}
