using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanManagerLib
{
    public static class InstanceManager
    {
   
        /*Static collections containing objects*/
        public static ObservableCollection<House> houseCollection = new ObservableCollection<House>();
        public static ObservableCollection<Room> roomCollection = new ObservableCollection<Room>();
        public static ObservableCollection<Guest> guestCollection = new ObservableCollection<Guest>();
        public static ObservableCollection<Reservation> reservationCollection = new ObservableCollection<Reservation>();


        /*---------------------------[Object creation methods]-------------------------------*/
        public static void CreateHouse(string houseName, byte NrRooms, string note)
        {
            int calculatedHouseId = InstanceManager.houseCollection.Count + 1;

            if (calculatedHouseId > 1)
            {
                foreach (House h in InstanceManager.houseCollection)
                {
                    if (h.HouseID >= calculatedHouseId)
                    {
                        calculatedHouseId = h.HouseID + 1;
                    }
                }
            }

            House newHouse = new House(calculatedHouseId, houseName, NrRooms, note);
            houseCollection.Add(newHouse);

            for (int i = 0; i < NrRooms; i++)
            {
                int calculatedRoomId = InstanceManager.roomCollection.Count + 1;
                if (calculatedRoomId > 1)
                {
                    foreach (Room r in InstanceManager.roomCollection)
                    {
                        if (r.RoomID >= calculatedRoomId)
                        {
                            calculatedRoomId = r.RoomID + 1;
                        }
                    }
                }

                roomCollection.Add(new Room(calculatedRoomId, 0,  calculatedRoomId.ToString(), 0, "Beállításra vár", newHouse));
            }

        }


        public static void CreateGuest(string familyName, string firstName, string tel, string mail, string address, string note)
        {
            int calculatedGuestId = 1;
            if (InstanceManager.guestCollection.Count != 0)
            {
                foreach (Guest g in InstanceManager.guestCollection)
                {
                    if (g.GuestId >= calculatedGuestId)
                    {
                        calculatedGuestId = g.GuestId + 1;
                    }
                }
            }

            InstanceManager.guestCollection.Add(new Guest(calculatedGuestId, null, familyName, firstName, tel, mail, address, note));
        }
        /*---------------------------[***************************]-------------------------------*/


        /*---------------------------[Object loader methods]-------------------------------*/
        public static void LoadHouse(string loadedId, string loadedName, string loadedNumRooms, string loadedNote)
        {
            houseCollection.Add(new House(int.Parse(loadedId), loadedName, byte.Parse(loadedNumRooms), loadedNote));

        }

        public static void LoadRoom(string loadedRoomId, string loadedReservationId, string loadedHouseId, string loadedRoomName, string loadedNumberOfBeds, string loadedNote)
        {
            House houseToLoad = null;

            foreach (House h in InstanceManager.houseCollection)
            {
                if (h.HouseID == int.Parse(loadedHouseId))
                {
                    houseToLoad = h;
                    break;
                }
            }

            roomCollection.Add(new Room(int.Parse(loadedRoomId), int.Parse(loadedReservationId), loadedRoomName, byte.Parse(loadedNumberOfBeds), loadedNote, houseToLoad));

        }

        public static void LoadGuest(string loadedGuestId, string loadedReservationId, string loadedFamilyName, string loadedFirstName, string loadedTel, string loadedAddress,
            string loadedMail, string loadedNote)
        {
            Reservation linkedReservation = null;

            foreach (Reservation res in reservationCollection)
            {
                if (res.ReservationId == int.Parse(loadedReservationId))
                {
                    linkedReservation = res;
                }
            }

            guestCollection.Add(new Guest(int.Parse(loadedGuestId), linkedReservation, loadedFamilyName, loadedFirstName, 
                loadedTel, loadedAddress, loadedMail, loadedNote));
        }
        /*---------------------------[***************************]-------------------------------*/



        /*---------------------------[Object removal methods]-------------------------------*/
        public static void RemoveHouse(House houseToRemove)
        {
            if (houseToRemove != null)
            {
                foreach (Room r in InstanceManager.roomCollection.ToList())
                {
                    if (r.ItsHouse == houseToRemove)
                    {
                        InstanceManager.roomCollection.Remove(r);
                    }
                }

                InstanceManager.houseCollection.Remove(houseToRemove);
                
            }

        }
        /*---------------------------[***************************]-------------------------------*/



    }
}
