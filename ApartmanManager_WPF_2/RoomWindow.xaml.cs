﻿using System;
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

        string DefaultRoomName = "Név/Szám";
        string DefaultBedNumber = "Ágyak";
        string DefaultNote = "Megjegyzés";

        public ObservableCollection<Room> filteredRooms = new ObservableCollection<Room>();

        private void ClearFields()
        {
            RoomNameField.Text = DefaultRoomName;
            BedsField.Text = DefaultBedNumber;
            NoteField.Text = DefaultNote;
            HouseSelector_SelectionChanged(null, null);
        }

        public RoomWindow()
        {
            InitializeComponent();
            ClearFields();
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
                PopulateRoomSetup();
            }
        }

        private void RoomListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (RoomListView.SelectedItem != null)
            {
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
            string[] gotRoomData = new string[6];
            bool check = true;
            StringBuilder errString = new StringBuilder();
          
            //get room name
            if (RoomNameField.Text != DefaultRoomName)
            {
                gotRoomData[(int)CustomTypes.enRoom.name] = RoomNameField.Text;
            }
            //get number of beds
            gotRoomData[(int)CustomTypes.enRoom.beds] = BedsField.Text;

            //get note
            if (NoteField.Text != DefaultNote)
            {
                gotRoomData[(int)CustomTypes.enRoom.note] = NoteField.Text;
            }
            else
            {
                gotRoomData[(int)CustomTypes.enRoom.note] = "-";
            }

            //if everything was ok, set room data
            if (check == true)
            {
                foreach (Room r in InstanceManager.roomCollection)
                {
                    if (r.RoomID == (((Room)RoomListView.SelectedItem).RoomID))
                    {
                        r.RoomName = gotRoomData[(int)CustomTypes.enRoom.name];
                        r.NumberOfBeds = byte.Parse(gotRoomData[(int)CustomTypes.enRoom.beds]);
                        r.Note = gotRoomData[(int)CustomTypes.enRoom.note];
                    }
                }
                ClearFields();
            }
            else
            {
                MessageBox.Show("Hiba a következő mezőkben:\n" + errString, "Érték hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
      

    }
}
