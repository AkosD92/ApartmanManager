using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApartmanManagerLib
{
    public class Room
    {
        private int roomID;
        private Reservation itsReservation;
        private House itsHouse;
        private string roomName;
        private byte numberOfBeds;
        private string note;

        public int RoomID{ get { return roomID; } set { roomID = value;  } }
        public Reservation ItsReservation{ get { return itsReservation; } set { itsReservation = value; } }
        public House ItsHouse { get { return itsHouse; } set { itsHouse = value; } }
        public string RoomName { get { return roomName; } set { roomName = value; } }
        public byte NumberOfBeds { get { return numberOfBeds; } set { numberOfBeds = value; } }
        public string Note { get { return note; } set { note = value; } }

        public Room(int roomID, Reservation reservation, House itsHouse, string roomName, byte numberOfBeds, string note)
        {
            this.roomID = roomID;
            this.itsReservation = reservation;
            this.roomName = roomName;
            this.numberOfBeds = numberOfBeds;
            this.note = note;
            this.itsHouse = itsHouse;

        }

        public override string ToString()
        {
            int houseID = 0;
            int reservationID = 0;

            if(itsHouse != null)
            {
                houseID = itsHouse.HouseID;
            }

            if (itsReservation != null)
            {
                reservationID = itsReservation.ReservationId;
            }



            return roomID.ToString() + "|" + reservationID + "|" + houseID.ToString()
                + "|" + roomName + "|" + numberOfBeds.ToString() + "|" + note;
        }

    }
}
