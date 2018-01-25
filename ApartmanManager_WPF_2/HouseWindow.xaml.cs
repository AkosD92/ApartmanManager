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
    /// <summary>
    /// Interaction logic for HouseWindow.xaml
    /// </summary>
    public partial class HouseWindow : Window
    {
        public HouseWindow()
        {
            InitializeComponent();
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
            string gotName= null;
            byte gotRooms = 0;
            string gotNote = null;
            bool check = true;
            StringBuilder errString = new StringBuilder() ;

            //check if each field was filled
            if (HouseNameField.Text != "Ház név")
            {
                gotName = HouseNameField.Text;
            }
            else
            {
                errString.AppendLine("- Ház neve"); ;
                check = false;
            }

            if (!Byte.TryParse(RoomNumberField.Text, out gotRooms))
            {
                errString.AppendLine("- Szobaszám");
                check = false;
            }

            if (NoteField.Text != "Megjegyzés (pl. cím stb.)")
            {
                gotNote = NoteField.Text;
            }else
            {
                gotNote="-";
            }

            if (check == true)
            {
                if (InstanceManager.CreateHouse(gotName, gotRooms, gotNote))
                {
                    MessageBox.Show("Ház hozzáadva!", "Művelet kész", MessageBoxButton.OK, MessageBoxImage.Information);
                    HouseNameField.Text = "Ház név";
                    RoomNumberField.Text= "Szobák száma";
                    NoteField.Text = "Megjegyzés (pl. cím stb.)";
                }
            }
            else
            {
                FieldError(errString);
            }




        }

        private void FieldError(StringBuilder sb)
        {
            MessageBox.Show("Hiba a következő mezőkben:\n"+sb, "Érték hiba!", MessageBoxButton.OK, MessageBoxImage.Error);
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
