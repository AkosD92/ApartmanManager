using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanManagerLib
{
    public class Guest : INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void pNotify([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int guestID;
        private Reservation itsReservation;

        private string familyName;
        private string firstName;
        private string phoneNumber;
        private string address;
        private string mail;
        private string note;

        public int GuestId { get { return this.guestID; } set { this.guestID = value; pNotify(); } }
        public Reservation ItsReservation { get { return this.itsReservation; } set { this.itsReservation = value; pNotify(); } }
        public string FamilyName { get { return this.familyName; } set { this.familyName = value; pNotify(); } }
        public string FirstName { get { return this.firstName; } set { this.firstName = value; pNotify(); } }
        public string PhoneNumber { get { return this.phoneNumber; } set { this.phoneNumber = value; pNotify(); } }
        public string Address { get { return this.address; } set { this.address = value; pNotify(); } }
        public string Mail { get { return this.mail; } set { this.mail = value; pNotify(); } }
        public string Note { get { return this.note; } set { this.note = value; pNotify(); } }

        public Guest(string arg1, string arg2)
        {
            firstName = arg1;
            familyName = arg2;

        }

        public Guest(int argGuestId, string[] argGuestData)
        {
            guestID = argGuestId;
            familyName = argGuestData[(int)CustomTypes.enGuest.familyname];
            firstName = argGuestData[(int)CustomTypes.enGuest.firstname];
            phoneNumber = argGuestData[(int)CustomTypes.enGuest.tel];
            address = argGuestData[(int)CustomTypes.enGuest.address];
            mail = argGuestData[(int)CustomTypes.enGuest.mail];
            note = argGuestData[(int)CustomTypes.enGuest.note];
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};{5};{6}", guestID, familyName, firstName,
                phoneNumber, address, mail, note);
        }


    }
}
