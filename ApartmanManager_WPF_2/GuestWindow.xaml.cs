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

        public GuestWindow()
        {
            InitializeComponent();
            ClearFields();
            CbxReservationHouse.ItemsSource = InstanceManager.houseCollection;
            CbxReservationRoom.ItemsSource = CalendarManager.availableRooms;
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
            if ((ArrivalField.SelectedDate != null) && (LeaveField.SelectedDate != null) && (CbxReservationHouse.SelectedItem != null))
            {
                CalendarManager.UpdateAvailableRooms((DateTime)ArrivalField.SelectedDate, (DateTime)LeaveField.SelectedDate, (House)CbxReservationHouse.SelectedItem);
            }
                

        }


        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder errString = new StringBuilder();
            bool check = true;

            //Personal data
            string[] gotGuestData = new string[7];
            
            //Accomodation data
            Room gotRoom = null;

            //Reservation data
            string[] gotResData = new string[12];


            //Read in the first name
            if (FirstNameField.Text != DefaultFirstName){gotGuestData[(int)CustomTypes.enGuest.firstname] = FirstNameField.Text;}
            else {
                check = false;
                errString.AppendLine(DefaultFirstName);
            }
            //Read in the family name
            if (FamilyNameField.Text != DefaultFamilyName){ gotGuestData[(int)CustomTypes.enGuest.familyname] = FamilyNameField.Text; }
            else{
                check = false;
                errString.AppendLine(DefaultFamilyName);
            }
            //Read in the tel number
            if (TelField.Text != DefaultTel){gotGuestData[(int)CustomTypes.enGuest.tel] = TelField.Text; }
            else {
                check = false;
                errString.AppendLine(DefaultTel);
            }
            //Read in the mail
            if (MailField.Text != DefaultMail){gotGuestData[(int)CustomTypes.enGuest.mail] = MailField.Text; }
            else {
                check = false;
                errString.AppendLine(DefaultMail);
            }
            //Read in the address
            if (AddressField.Text != DefaultAddress){ gotGuestData[(int)CustomTypes.enGuest.address] = AddressField.Text;}
            else {
                check = false;
                errString.AppendLine(DefaultAddress);
            }
            //Read in the guest note
            if (GuestNoteField.Text != DefaultGuestNote) { gotGuestData[(int)CustomTypes.enGuest.note] = GuestNoteField.Text; }
            else {
                gotGuestData[(int)CustomTypes.enGuest.note] = "-";     
            }

            //Read room data
            gotRoom = (Room)CbxReservationRoom.SelectedItem;
            gotResData[(int)CustomTypes.enReservation.roomId] = gotRoom.RoomID.ToString();

            gotResData[(int)CustomTypes.enReservation.arrival] = ArrivalField.SelectedDate.ToString();
            gotResData[(int)CustomTypes.enReservation.leave] = LeaveField.SelectedDate.ToString();

            //Get number of persons
            gotResData[(int)CustomTypes.enReservation.persons] = PersonsField.Text;

            //Get number of infants
            gotResData[(int)CustomTypes.enReservation.infants] = InfantsField.Text;

            //Get cost
            gotResData[(int)CustomTypes.enReservation.cost] = CostField.Text;

            //Get pay type
            gotResData[(int)CustomTypes.enReservation.paytype] = CbxPayMethodField.SelectedIndex.ToString();

            //Get prepaid value
            gotResData[(int)CustomTypes.enReservation.prepaid] = PrepaidField.Text;

            //Get remainder value 
            gotResData[(int)CustomTypes.enReservation.remainder] = RemainderField.Text;

            //Read in the reservation note
            if (ReservationNoteField.Text != DefaultReservationNote) { gotResData[(int)CustomTypes.enReservation.note] = ReservationNoteField.Text; }
            else
            {
                gotResData[(int)CustomTypes.enReservation.note] = "-";
            }

            //if everything was ok, create guest
            if (check == true)
            {
                Guest guestAdded = InstanceManager.AddGuest(gotGuestData, CustomTypes.enObjAddType.CREATE);
                gotResData[(int)CustomTypes.enReservation.guestId] = guestAdded.GuestId.ToString();
                Reservation resAdded =  InstanceManager.AddReservation(gotResData, CustomTypes.enObjAddType.CREATE);

                resAdded.ItsGuest = guestAdded;
                resAdded.ItsRoom = gotRoom;

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
                dHouseField.Text = ((Reservation)ActiveGuestListView.SelectedItem).ItsRoom.ItsHouse.HouseName.ToString();
                dRoomField.Text = ((Reservation)ActiveGuestListView.SelectedItem).ItsRoom.RoomName.ToString();

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

        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            Reservation selectedRes = (Reservation)ActiveGuestListView.SelectedItem;

            selectedRes.Arrival = DateTime.Parse(dArrivalField.Text);
            selectedRes.Leave = DateTime.Parse(dLeaveField.Text);
            selectedRes.NumberOfPersons = byte.Parse(dPersonsField.Text);
            selectedRes.NumberOfInfants = byte.Parse(dInfantsField.Text);
            selectedRes.Cost = int.Parse(dCostField.Text);
            selectedRes.CostPrepaid = int.Parse(dPaidField.Text);
            selectedRes.CostRemainder = int.Parse(dRemainderField.Text);
            selectedRes.Note = dNoteField.Text;

        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ActiveGuestListView.SelectedIndex != -1)
            {
                MessageBoxResult result = MessageBox.Show("Biztosan törli a kiválasztott vendéget és foglalást?", "Figyelem!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    Reservation selectedRes = (Reservation)ActiveGuestListView.SelectedItem;
                    InstanceManager.RemoveReservation(selectedRes);
                }
            }

        }

    }



}
