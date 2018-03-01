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
   
    public partial class GuestWindow : Window
    {
        string DefaultFirstName = "Keresztnév";
        string DefaultFamilyName = "Vezetéknév";
        string DefaultTel = "Telefonszám";
        string DefaultMail = "E-mail cím";
        string DefaultAddress = "Lakcím";
        string DefaultNote = "Megjegyzés";

        public GuestWindow()
        {
            InitializeComponent();
            ClearFields();
            GuestListView.ItemsSource = InstanceManager.archiveGuestCollection;
        }

        private void ClearFields()
        {
            FirstNameField.Text = DefaultFirstName;
            FamilyNameField.Text = DefaultFamilyName;
            TelField.Text = DefaultTel;
            MailField.Text = DefaultMail;
            AddressField.Text = DefaultAddress;
            NoteField.Text = DefaultNote;
        }



        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            string gotFirstName = null, gotFamilyName = null, gotTel = null, gotMail = null, gotAddress = null, gotNote = null;
            StringBuilder errString = new StringBuilder();
            bool check = true;

            //Read in the first name
            if (FirstNameField.Text != DefaultFirstName){gotFirstName = FirstNameField.Text;}
            else {
                check = false;
                errString.AppendLine(DefaultFirstName);
            }
            //Read in the family name
            if (FamilyNameField.Text != DefaultFamilyName){gotFamilyName = FamilyNameField.Text; }
            else {
                check = false;
                errString.AppendLine(DefaultFamilyName);
            }
            //Read in the tel number
            if (TelField.Text != DefaultTel) { gotTel = TelField.Text;}
            else{
                check = false;
                errString.AppendLine(DefaultTel);
            }
            //Read in the mail
            if (MailField.Text != DefaultMail) { gotMail = MailField.Text; }
            else {
                check = false;
                errString.AppendLine(DefaultMail);
            }
            //Read in the address
            if (AddressField.Text != DefaultAddress) { gotAddress = AddressField.Text; }
            else {
                check = false;
                errString.AppendLine(DefaultAddress);
            }
            //Read in the note
            if (NoteField.Text != DefaultNote) { gotNote = NoteField.Text; }
            else {
                gotNote = "-";     
            }

            //if everything was ok, create guest
            if (check == true)
            {
                InstanceManager.CreateGuest(gotFamilyName, gotFirstName, gotTel, gotMail, gotAddress, gotNote);
                MessageBox.Show("Vendég hozzáadva!", "Művelet kész", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();
            }
            else { MessageBox.Show("Hiba a következő mezőkben:\n" + errString, "Érték hiba!", MessageBoxButton.OK, MessageBoxImage.Error); }

        }


   
    }



}
