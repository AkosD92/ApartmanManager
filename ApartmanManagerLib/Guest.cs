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


        public Guest(int guestID, Reservation itsReservation, string familyName, string firstName, string phoneNumber, string address, string mail, string note)
        {
            this.guestID = guestID;
            this.itsReservation = itsReservation;
            this.familyName = familyName;
            this.firstName = firstName;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.mail = mail;
            this.note = note;
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

            return this.guestID.ToString() + "|" + ReservationId.ToString() + "|" + this.familyName + "|" + this.firstName + "|" + this.phoneNumber
                + "|" + this.address + "|" + this.mail + "|" + this.note;
        }


    }
}
