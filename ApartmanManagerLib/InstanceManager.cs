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

                roomCollection.Add(new Room(calculatedRoomId, null, newHouse,  calculatedRoomId.ToString(), 0, "Beállításra vár"));
            }

        }


        public static Guest CreateGuest(string familyName, string firstName, string tel, string mail, string address, string note)
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

            Guest newGuest = new Guest(calculatedGuestId, null, familyName, firstName, tel, mail, address, note);
            InstanceManager.guestCollection.Add(newGuest);
            return newGuest;
        }


        public static void CreateReservation(Room pItsRoom, Guest pItsGuest, DateTime pArrival, DateTime pLeave, byte pPersons, byte pInfants, CustomTypes.enPayMethod pPayMethod,
            int pCost, int pCostPrepaid, int pCostRemainder, string pNote)
        {
            int calculatedReservationId = 1;
            if (InstanceManager.reservationCollection.Count != 0)
            {
                foreach (Reservation r in InstanceManager.reservationCollection)
                {
                    if (r.ReservationId >= calculatedReservationId)
                    {
                        calculatedReservationId= r.ReservationId + 1;
                    }
                }
            }

            InstanceManager.reservationCollection.Add(new Reservation(calculatedReservationId, pItsRoom, pItsGuest, pArrival, pLeave, pPersons, pInfants, pPayMethod, pCost, pCostPrepaid,
                pCostRemainder, pNote));
        }


        /*---------------------------[***************************]-------------------------------*/


        /*---------------------------[Object loader methods]-------------------------------*/

        public static void LoadReservation(string loadedReservationId, string loadedRoomId, string loadedGestId, string loadedArrival, string loadedLeave, 
            string loadedPersons, string loadedInfants, string loadedPaytype, string loadedCost, string loadedCostPrepaid, string loadedCostRemainder, string loadedNote)
        {
            CustomTypes.enPayMethod parsedPaytype = (CustomTypes.enPayMethod)Enum.Parse(typeof(CustomTypes.enPayMethod), loadedPaytype);
            Room roomToLoad = null;
            Guest guestToLoad = null;

            foreach (Room r in roomCollection)
            {
                if (r.RoomID == int.Parse(loadedRoomId))
                {
                    roomToLoad = r;
                    break;
                }
            }

            foreach (Guest g in guestCollection)
            {
                if (g.GuestId == int.Parse(loadedGestId))
                {
                    guestToLoad = g;
                    break;
                }
            }

            Reservation ReservationToLoad = new Reservation(int.Parse(loadedReservationId), roomToLoad, guestToLoad, DateTime.Parse(loadedArrival), DateTime.Parse(loadedLeave), byte.Parse(loadedPersons),
                byte.Parse(loadedInfants), parsedPaytype, int.Parse(loadedCost), int.Parse(loadedCostPrepaid), int.Parse(loadedCostRemainder), loadedNote);

            ReservationToLoad.ItsRoom.ItsReservation = ReservationToLoad;

            reservationCollection.Add(ReservationToLoad);

        }

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

            roomCollection.Add(new Room(int.Parse(loadedRoomId), null, houseToLoad, loadedRoomName, byte.Parse(loadedNumberOfBeds), loadedNote));

        }

        public static void LoadArchiveGuest(string loadedGuestId, string loadedReservationId, string loadedFamilyName, string loadedFirstName, string loadedTel, string loadedAddress,
            string loadedMail, string loadedNote)
        {
            Reservation linkedReservation = null;

            guestCollection.Add(new Guest(int.Parse(loadedGuestId), linkedReservation, loadedFamilyName, loadedFirstName, 
                loadedTel, loadedAddress, loadedMail, loadedNote));
        }

        public static void LoadActiveGuest(string loadedGuestId, string loadedReservationId, string loadedFamilyName, string loadedFirstName, string loadedTel, string loadedAddress,
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
