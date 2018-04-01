using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApartmanManagerLib
{
    public class Reservation
    {
        //Fields
        private int reservationID;
        private Room itsRoom;
        private Guest itsGuest;


        private DateTime arrival;
        private DateTime leave;
        private byte numberOfPersons;
        private byte numberOfInfants;

        private CustomTypes.enPayMethod payMethod;
        private int cost;
        private int costPrepaid;
        private int costRemainder;

        private string note;

        
        //Properties
        public int ReservationId{get{ return reservationID; } set{ reservationID = value; } }
        public Room ItsRoom { get { return itsRoom; } set { itsRoom = value; } }
        public Guest ItsGuest { get { return itsGuest; } set { itsGuest = value; } }

        public DateTime Arrival { get { return arrival; } set { arrival = value; } }
        public DateTime Leave { get { return leave; } set { leave = value; } }
        public byte NumberOfPersons { get { return numberOfPersons; } set { numberOfPersons = value; } }
        public byte NumberOfInfants { get { return numberOfInfants; } set { numberOfInfants = value; } }
        public CustomTypes.enPayMethod PayMethod { get { return payMethod; } set { payMethod = value; } }
        public int Cost { get { return cost; } set { cost = value; } }
        public int CostPrepaid { get { return costPrepaid; } set { costPrepaid = value; } }
        public int CostRemainder { get { return costRemainder; } set { costRemainder = value; } }
        public string Note { get { return note; } set { note = value; } }

        //Constructor
        public Reservation(int reservationID, Room itsRoom, Guest itsGuest, DateTime arrival, DateTime leave, byte numberOfPersons, byte numberOfInfants,
            CustomTypes.enPayMethod payMethod, int cost, int costPrepaid, int costRemainder, string note)
        {
            this.reservationID = reservationID;
            this.itsRoom = itsRoom;
            this.itsGuest = itsGuest;
            this.arrival = arrival;
            this.leave = leave;
            this.numberOfPersons = numberOfPersons;
            this.numberOfInfants = numberOfInfants;
            this.payMethod = payMethod;
            this.cost = cost;
            this.costPrepaid = costPrepaid;
            this.costRemainder = costRemainder;
            this.note = note;
        }

        public override string ToString()
        {
            return reservationID.ToString() + "|" + itsRoom.RoomID + "|" + itsGuest.GuestId + "|" + arrival.ToString() + "|" + leave.ToString() + "|" + numberOfPersons.ToString() + 
                "|" + numberOfInfants.ToString() + "|" + payMethod + "|" + cost.ToString() + "|" + costPrepaid.ToString() + "|" + costRemainder.ToString() + "|" + note;
        }
    }
}
