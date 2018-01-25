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
        private int reservationID;
        private string roomName;
        private byte numberOfBeds;
        private string note;
        private House itsHouse;

        public int RoomID{ get { return roomID; } set { roomID = value;  } }
        public int ReservationID{ get { return reservationID; } set { reservationID = value; } }
        public string RoomName { get { return roomName; } set { roomName = value; } }
        public byte NumberOfBeds { get { return numberOfBeds; } set { numberOfBeds = value; } }
        public string Note { get { return note; } set { note = value; } }
        public House ItsHouse { get { return itsHouse; } set { itsHouse = value; } }

        public Room(int roomID, int reservationID, string roomName, byte numberOfBeds, string note, House itsHouse)
        {
            this.roomID = roomID;
            this.reservationID = reservationID;
            this.roomName = roomName;
            this.numberOfBeds = numberOfBeds;
            this.note = note;
            this.itsHouse = itsHouse;

        }

        public override string ToString()
        {
            int houseID = this.itsHouse.HouseID;

            return roomID.ToString() + "|" + reservationID.ToString() + "|" + houseID.ToString()
                + "|" + roomName + "|" + numberOfBeds.ToString() + "|" + note;
        }

    }
}
