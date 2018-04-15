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

        private Guest itsGuest;
        private Room itsRoom;

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

        public Guest ItsGuest { get { return itsGuest; } set { itsGuest = value; } }
        public Room ItsRoom { get { return itsRoom; } set { itsRoom = value; } }

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
        public Reservation(int argResId, Room argItsRoom, Guest argItsGuest, string[] argResData )
        {
            reservationID = argResId;
            itsRoom = argItsRoom;
            itsGuest = argItsGuest;

            arrival = DateTime.Parse(argResData[(int)CustomTypes.enReservation.arrival]);
            leave = DateTime.Parse(argResData[(int)CustomTypes.enReservation.leave]);
            numberOfPersons = byte.Parse(argResData[(int)CustomTypes.enReservation.persons]);
            numberOfInfants = byte.Parse(argResData[(int)CustomTypes.enReservation.infants]);
            payMethod = (CustomTypes.enPayMethod)Enum.Parse(typeof(CustomTypes.enPayMethod), argResData[(int)CustomTypes.enReservation.paytype]);
            cost = int.Parse(argResData[(int)CustomTypes.enReservation.cost]);
            costPrepaid = int.Parse(argResData[(int)CustomTypes.enReservation.prepaid]);
            costRemainder = int.Parse(argResData[(int)CustomTypes.enReservation.remainder]);
            note = argResData[(int)CustomTypes.enReservation.note];
        }

        public override string ToString()
        {
            return string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}", reservationID, ItsRoom.RoomID, ItsGuest.GuestId, arrival, leave, numberOfPersons,
                numberOfInfants, payMethod, cost, costPrepaid, costRemainder, note);
        }
    }
}
