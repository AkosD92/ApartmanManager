using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApartmanManagerLib
{
    public class Reservation
    {
        private uint reservationID;
        private uint guestID;
        private uint roomID;

        private byte numberOfPersons;
        private byte numberOfInfants;

        private CustomTypes.enPayMethod payMethod;
        private CustomTypes.enSzepType szepType;

        private int cost;
        private int totalCost;
        private int costPaid;
        private int costRemainder;

        private DateTime arrival;
        private DateTime leave;

        private string note;


        public uint ReservationId{get{ return this.reservationID; } set{ this.reservationID = value; } }

    }
}
