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
   

        public static ObservableCollection<House> houseCollection = new ObservableCollection<House>();
        public static ObservableCollection<Room> roomCollection = new ObservableCollection<Room>();


        public static bool CreateHouse(string houseName, byte NrRooms, string note)
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

                roomCollection.Add(new Room(calculatedRoomId, 0,  "-", 0, "Beállításra vár", newHouse));
            }
            

            return true;
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

            roomCollection.Add(new Room(int.Parse(loadedRoomId), int.Parse(loadedReservationId), loadedRoomName, byte.Parse(loadedNumberOfBeds), loadedNote, houseToLoad));

        }


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

       
        

    }
}
