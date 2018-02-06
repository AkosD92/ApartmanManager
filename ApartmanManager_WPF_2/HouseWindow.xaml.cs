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

namespace ApartmanManager
{

    public partial class HouseWindow : Window
    {
        string DefaultHouseName = "Ház név";
        string DefaultRoomNumber = "Szobák száma";
        string DefaultNote = "Megjegyzés (pl. cím stb.)";

        public void ClearFields()
        {
            HouseNameField.Text = DefaultHouseName;
            RoomNumberField.Text = DefaultRoomNumber;
            NoteField.Text = DefaultNote;
        }

        public HouseWindow()
        {
            InitializeComponent();
            ClearFields();
            HouseListView.ItemsSource = InstanceManager.houseCollection;
        }
     

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Add House button clicked
        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //create locals
            string gotName= null, gotNote = null;
            byte gotRooms = 0;

            bool check = true;
            StringBuilder errString = new StringBuilder() ;

            //get house name
            if (HouseNameField.Text != DefaultHouseName) { gotName = HouseNameField.Text;}
            else {
                errString.AppendLine(DefaultHouseName); ;
                check = false;
            }
            //get number of rooms
            if (!Byte.TryParse(RoomNumberField.Text, out gotRooms))
            {
                errString.AppendLine(DefaultRoomNumber);
                check = false;
            }
            //get note
            if (NoteField.Text != DefaultNote){ gotNote = NoteField.Text; }
            else { gotNote="-";}

            //if everything was ok, create the house and the rooms
            if (check == true)
            {
                InstanceManager.CreateHouse(gotName, gotRooms, gotNote); 
                MessageBox.Show("Ház hozzáadva!", "Művelet kész", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();
            }
            //else show error window
            else{ MessageBox.Show("Hiba a következő mezőkben:\n" + errString, "Érték hiba!", MessageBoxButton.OK, MessageBoxImage.Error); }

        }

 
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {

            if (HouseListView.SelectedIndex != -1)
            {
                MessageBoxResult result = MessageBox.Show("Biztosan törli a kiválasztott házat?", "Figyelem!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    InstanceManager.RemoveHouse((House)HouseListView.SelectedItem);
                }
            }
    
        }
    }
}
