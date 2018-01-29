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
using System.Windows.Shapes;

using ApartmanManagerLib;
using System.Collections.ObjectModel;

namespace ApartmanManager
{

    public partial class RoomWindow : Window
    {

        string DefaultRoomName = "Szoba neve/száma";
        string DefaultBedNumber = "Ágyak száma";
        string DefaultNote = "Megjegyzés";

        public ObservableCollection<Room> filteredRooms = new ObservableCollection<Room>();

        public RoomWindow()
        {
            InitializeComponent();
            RoomListView.ItemsSource = filteredRooms;
            HouseSelector.ItemsSource = InstanceManager.houseCollection;

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HouseSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filteredRooms.Clear();
            foreach (Room r in InstanceManager.roomCollection)
            {
                if (r.ItsHouse == ((House)HouseSelector.SelectedItem))
                {
                    filteredRooms.Add(r);
                }
            }

        }

        private void RoomListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (RoomListView.SelectedItem != null)
            {
                ParamTab.IsEnabled = true;
                PopulateRoomSetup();
            }
        }

        private void RoomListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RoomListView.SelectedItem != null)
            {
                ParamTab.IsEnabled = true;
                ParamTab.IsSelected = true;
                PopulateRoomSetup();
            }
        }


        private void PopulateRoomSetup()
        {
            HouseNameField.Text = ((House)HouseSelector.SelectedItem).HouseName;

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //create locals
            string gotName = null;
            byte gotBeds = 0;
            string gotNote = null;
            bool check = true;
            StringBuilder errString = new StringBuilder();

          
            //check if each field was filled
            if (RoomNameField.Text != DefaultRoomName)
            {
                gotName = RoomNameField.Text;
            }
            else
            {
                gotName = "-";
            }

            if (!Byte.TryParse(BedsField.Text, out gotBeds))
            {
                errString.AppendLine("- Ágyszám");
                check = false;
            }

            if (NoteField.Text != DefaultNote)
            {
                gotNote = NoteField.Text;
            }
            else
            {
                gotNote = "-";
            }

            if (check == true)
            {
                foreach (Room r in InstanceManager.roomCollection)
                {
                    if (r.RoomID == (((Room)RoomListView.SelectedItem).RoomID))
                    {
                        r.RoomName = gotName;
                        r.NumberOfBeds = gotBeds;
                        r.Note = gotNote;
                    }
                }
                RoomNameField.Text = DefaultRoomName;
                BedsField.Text = DefaultBedNumber;
                NoteField.Text = DefaultNote;
                HouseSelector_SelectionChanged(null, null);
                RoomTab.IsSelected = true;
            }
            else
            {
                FieldError(errString);
            }


        }
        private void FieldError(StringBuilder sb)
        {
            MessageBox.Show("Hiba a következő mezőkben:\n" + sb, "Érték hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }
}
