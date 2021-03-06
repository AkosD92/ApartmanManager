﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace ApartmanManagerLib
{
    public class Room : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void pNotify([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int roomID;
        private Reservation itsReservation;
        private House itsHouse;
        private string roomName;
        private byte numberOfBeds;
        private string note;

        public int RoomID{ get { return roomID; } set { roomID = value;  pNotify(); } }
        public Reservation ItsReservation{ get { return itsReservation; } set { itsReservation = value; pNotify(); } }
        public House ItsHouse { get { return itsHouse; } set { itsHouse = value; pNotify(); } }
        public string RoomName { get { return roomName; } set { roomName = value; pNotify(); } }
        public byte NumberOfBeds { get { return numberOfBeds; } set { numberOfBeds = value; pNotify(); } }
        public string Note { get { return note; } set { note = value; pNotify();} }

        //Not stored fields, calendar fields
        private bool isOccupied;
        public bool IsOccupied { get { return isOccupied; } set { isOccupied = value; } }




        public Room(int argRoomID, House argItsHouse, string[] argRoomData)
        {
            roomID = argRoomID;
            itsHouse = argItsHouse;
            roomName = argRoomData[(int)CustomTypes.enRoom.name];
            numberOfBeds = byte.Parse(argRoomData[(int)CustomTypes.enRoom.beds]);
            note = argRoomData[(int)CustomTypes.enRoom.note];

            isOccupied = false;
        }

        public override string ToString()
        {
            int houseID = 0;

            if(itsHouse != null)
            {
                houseID = itsHouse.HouseID;
            }


            return string.Format("{0};{1};{2};{3};{4}", roomID, houseID, roomName, numberOfBeds, note);
        }

    }
}
