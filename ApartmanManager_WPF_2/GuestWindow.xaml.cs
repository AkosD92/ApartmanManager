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

namespace ApartmanManager
{
    /// <summary>
    /// Interaction logic for GuestWindow.xaml
    /// </summary>
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

        }
    }
}
