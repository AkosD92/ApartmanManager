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

        public Room(int argRoomID, Reservation argItsReservation, House argItsHouse, string[] argRoomData)
        {
            roomID = argRoomID;
            itsReservation = argItsReservation;
            itsHouse = argItsHouse;
            roomName = argRoomData[(int)CustomTypes.enRoom.name];
            numberOfBeds = byte.Parse(argRoomData[(int)CustomTypes.enRoom.beds]);
            note = argRoomData[(int)CustomTypes.enRoom.note];
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

            return string.Format("{0};{1};{2};{3};{4};{5}", roomID, reservationID, houseID, roomName, numberOfBeds, note);
        }

    }
}
