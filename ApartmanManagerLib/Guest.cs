using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanManagerLib
{
    public class Guest
    {
        private uint guestID;
        private Reservation itsReservation;

        private string familyName;
        private string firstName;
        private string phoneMumber;
        private string address;
        private string mail;
        private string note;

        public uint GuestId { get { return this.guestID; } set { this.guestID = value; } }
        public Reservation ItsReservation { get { return this.itsReservation; } set { this.itsReservation = value; } }
        public string FamilyName { get { return this.familyName; } set { this.familyName = value; } }
        public string FirstName { get { return this.firstName; } set { this.firstName = value; } }
        public string PhoneNumber { get { return this.phoneMumber; } set { this.phoneMumber = value; } }
        public string Address { get { return this.address; } set { this.address = value; } }
        public string Mail { get { return this.mail; } set { this.mail = value; } }
        public string Note { get { return this.note; } set { this.note = value; } }

        public override string ToString()
        {
            return this.guestID.ToString() + "|" + this.itsReservation.ReservationId.ToString() + "|" + this.familyName + "|" + this.firstName + "|" + this.phoneMumber
                + "|" + this.address + "|" + this.mail + "|" + this.note;
        }


    }
}
