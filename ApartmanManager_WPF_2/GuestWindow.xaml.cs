using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ObservableCollection<Room> filteredRooms = new ObservableCollection<Room>();

        string DefaultFirstName = "Keresztnév";
        string DefaultFamilyName = "Vezetéknév";
        string DefaultTel = "Telefonszám";
        string DefaultMail = "E-mail cím";
        string DefaultAddress = "Lakcím";
        string DefaultGuestNote = "Megjegyzés a vendéghez";
        string DefaultPersons = "Fő";
        string DefaultInfants = "Fő";
        string DefaultCost = "Végösszeg";
        string DefaultPrepaid = "Ebből fizetve";
        string DefaultRemainder = "Hátralék";
        string DefaultReservationNote = "Megjegyzés a foglaláshoz";
        string PayMethodError = "Fizetés típusa";

        public GuestWindow()
        {
            InitializeComponent();
            ClearFields();
            CbxReservationHouse.ItemsSource = InstanceManager.houseCollection;
            CbxReservationRoom.ItemsSource = filteredRooms;
            ActiveGuestListView.ItemsSource = InstanceManager.reservationCollection;
        }

        private void ClearFields()
        {
            FirstNameField.Text = DefaultFirstName;
            FamilyNameField.Text = DefaultFamilyName;
            TelField.Text = DefaultTel;
            MailField.Text = DefaultMail;
            AddressField.Text = DefaultAddress;
            GuestNoteField.Text = DefaultGuestNote;

            PersonsField.Text = DefaultPersons;
            InfantsField.Text = DefaultInfants;
            CostField.Text = DefaultCost;
            PrepaidField.Text = DefaultPrepaid;
            RemainderField.Text = DefaultRemainder;
            ReservationNoteField.Text = DefaultReservationNote;
        }

        private void CbxReservationHouse_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            filteredRooms.Clear();
            foreach (Room r in InstanceManager.roomCollection)
            {
                if (r.ItsHouse == ((House)CbxReservationHouse.SelectedItem))
                {
                    filteredRooms.Add(r);
                }
            }

        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Personal data
            string gotFirstName = null, gotFamilyName = null, gotTel = null, gotMail = null, gotAddress = null, gotGuestNote = null;
            StringBuilder errString = new StringBuilder();

            //Accomodation data
            Room gotRoom = null;
            Guest gotGuest = null;

            //Reservation data
            DateTime gotArrival;
            DateTime gotLeave;
            byte gotPersons = 0;
            byte gotInfants = 0;
            int gotCost = 0;
            CustomTypes.enPayMethod gotPayMethod;
            int gotPrepaid = 0;
            int gotRemainder = 0;
            string gotReservationNote;

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
            //Read in the guest note
            if (GuestNoteField.Text != DefaultGuestNote) { gotGuestNote = GuestNoteField.Text; }
            else {
                gotGuestNote = "-";     
            }

            //Read room data
            gotRoom = (Room)CbxReservationRoom.SelectedItem;

            gotArrival = (DateTime)ArrivalField.SelectedDate;
            gotLeave = (DateTime)LeaveField.SelectedDate;

            //Get number of persons
            if (!Byte.TryParse(PersonsField.Text, out gotPersons))
            {
                errString.AppendLine(DefaultPersons);
                check = false;
            }
            //Get number of infants
            if (!Byte.TryParse(InfantsField.Text, out gotInfants))
            {
                errString.AppendLine(DefaultInfants);
                check = false;
            }
            //Get cost
            if (!Int32.TryParse(CostField.Text, out gotCost))
            {
                errString.AppendLine(DefaultCost);
                check = false;
            }
            //Get pay type
            switch (CbxPayMethodField.SelectedIndex)
            {
                case 0:
                    gotPayMethod = CustomTypes.enPayMethod.KARTYA;
                    break;
                case 1:
                    gotPayMethod = CustomTypes.enPayMethod.KESZPENZ;
                    break;
                case 2:
                    gotPayMethod = CustomTypes.enPayMethod.SZ_OTP;
                    break;
                case 3:
                    gotPayMethod = CustomTypes.enPayMethod.SZ_MKB;
                    break;
                case 4:
                    gotPayMethod = CustomTypes.enPayMethod.SZ_KNH;
                    break;
                default:
                    gotPayMethod = CustomTypes.enPayMethod.KESZPENZ;
                    errString.AppendLine(PayMethodError);
                    break;
            }
            //Get prepaid value
            if (!Int32.TryParse(PrepaidField.Text, out gotPrepaid))
            {
                errString.AppendLine(DefaultPrepaid);
                check = false;
            }
            //Get remainder value
            if (!Int32.TryParse(RemainderField.Text, out gotRemainder))
            {
                errString.AppendLine(DefaultRemainder);
                check = false;
            }
            //Read in the reservation note
            if (ReservationNoteField.Text != DefaultReservationNote) { gotReservationNote = ReservationNoteField.Text; }
            else
            {
                gotReservationNote = "-";
            }

            //if everything was ok, create guest
            if (check == true)
            {
                Guest createdGuest = InstanceManager.CreateGuest(gotFamilyName, gotFirstName, gotTel, gotMail, gotAddress, gotGuestNote);
                InstanceManager.CreateReservation(gotRoom, createdGuest, gotArrival, gotLeave, gotPersons, gotInfants, gotPayMethod, gotCost, gotPrepaid, gotRemainder, gotReservationNote);
                MessageBox.Show("Vendég hozzáadva!", "Művelet kész", MessageBoxButton.OK, MessageBoxImage.Information);
                ClearFields();
            }
            else { MessageBox.Show("Hiba a következő mezőkben:\n" + errString, "Érték hiba!", MessageBoxButton.OK, MessageBoxImage.Error); }

        }

        //If the prepaid field changed calculate prepaid
        private void PrepaidField_TextChanged(object sender, TextChangedEventArgs e)
        {
            int costValue = 0;
            int prepaidValue = 0;
            int remainderValue = 0;

            Int32.TryParse(CostField.Text, out costValue);
            Int32.TryParse(PrepaidField.Text, out prepaidValue);

            remainderValue = costValue - prepaidValue;
            RemainderField.Text = Convert.ToString(remainderValue);
        }

        private void ActiveGuestListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ActiveGuestListView.SelectedItem != null)
            {
                dReservationIdField.Text = ((Reservation)ActiveGuestListView.SelectedItem).ReservationId.ToString();
                dRoomIdField.Text = ((Reservation)ActiveGuestListView.SelectedItem).ItsRoom.RoomID.ToString();
                dGuestIdField.Text = ((Reservation)ActiveGuestListView.SelectedItem).ItsGuest.GuestId.ToString();
                dArrivalField.Text = ((Reservation)ActiveGuestListView.SelectedItem).Arrival.ToString();
                dLeaveField.Text = ((Reservation)ActiveGuestListView.SelectedItem).Leave.ToString();
                dPersonsField.Text = ((Reservation)ActiveGuestListView.SelectedItem).NumberOfPersons.ToString();
                dInfantsField.Text = ((Reservation)ActiveGuestListView.SelectedItem).NumberOfInfants.ToString();
                dPaytypeField.Text = ((Reservation)ActiveGuestListView.SelectedItem).PayMethod.ToString();
                dCostField.Text = ((Reservation)ActiveGuestListView.SelectedItem).Cost.ToString();
                dPaidField.Text = ((Reservation)ActiveGuestListView.SelectedItem).CostPrepaid.ToString();
                dRemainderField.Text = ((Reservation)ActiveGuestListView.SelectedItem).CostRemainder.ToString();
                dNoteField.Text = ((Reservation)ActiveGuestListView.SelectedItem).Note;
            }
        }

       
    }



}
