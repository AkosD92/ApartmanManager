using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanManagerLib
{
    public class Guest
    {
        private int guestID;
        private Reservation itsReservation;

        private string familyName;
        private string firstName;
        private string phoneNumber;
        private string address;
        private string mail;
        private string note;

        public int GuestId { get { return this.guestID; } set { this.guestID = value; } }
        public Reservation ItsReservation { get { return this.itsReservation; } set { this.itsReservation = value; } }
        public string FamilyName { get { return this.familyName; } set { this.familyName = value; } }
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }
        public string PhoneNumber { get { return this.phoneNumber; } set { this.phoneNumber = value; } }
        public string Address { get { return this.address; } set { this.address = value; } }
        public string Mail { get { return this.mail; } set { this.mail = value; } }
        public string Note { get { return this.note; } set { this.note = value; } }


        public Guest(int argGuestId, Reservation argItsReservation,  string[] argGuestData)
        {
            guestID = argGuestId;
            itsReservation = argItsReservation;
            familyName = argGuestData[(int)CustomTypes.enGuest.familyname];
            firstName = argGuestData[(int)CustomTypes.enGuest.firstname];
            phoneNumber = argGuestData[(int)CustomTypes.enGuest.tel];
            address = argGuestData[(int)CustomTypes.enGuest.address];
            mail = argGuestData[(int)CustomTypes.enGuest.mail];
            note = argGuestData[(int)CustomTypes.enGuest.note];
        }

        public override string ToString()
        {
            int ReservationId;
            if (this.itsReservation != null)
            {
                ReservationId = this.itsReservation.ReservationId;
            }
            else
            {
                ReservationId = 0;
            }

            return string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", guestID, ReservationId, familyName, firstName,
                phoneNumber, address, mail, note);
        }


    }
}
