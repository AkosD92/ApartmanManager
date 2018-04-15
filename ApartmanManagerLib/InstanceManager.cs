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



        /*---------------------------[Object removal methods]-------------------------------*/
        public static void RemoveHouse(House houseToRemove)
        {
            if (houseToRemove != null)
            {
                foreach (Room r in roomCollection.ToList())
                {
                    if (r.ItsHouse == houseToRemove)
                    {
                        roomCollection.Remove(r);
                    }
                }

                houseCollection.Remove(houseToRemove);
                
            }

        }

        public static void RemoveReservation(Reservation resToRemove)
        {
            resToRemove.ItsGuest.ItsReservation = null;
            resToRemove.ItsRoom.ItsReservation = null;

            reservationCollection.Remove(resToRemove);
        }
        /*---------------------------[***************************]-------------------------------*/

        public static House AddHouse(string[] argFileds, CustomTypes.enObjAddType argHandleMethod)
        {
            House houseToAdd = null;
            if (argHandleMethod == CustomTypes.enObjAddType.CREATE)
            {
                int calculatedHouseId = houseCollection.Count + 1;
                if (calculatedHouseId > 1)
                {
                    foreach (House h in houseCollection)
                    {
                        if (h.HouseID >= calculatedHouseId)
                        {
                            calculatedHouseId = h.HouseID + 1;
                        }
                    }
                }

                houseToAdd = new House(calculatedHouseId, argFileds);
                houseCollection.Add(houseToAdd);

                for (int i = 0; i < byte.Parse(argFileds[(int)CustomTypes.enHouse.rooms]); i++)
                {
                    int calculatedRoomId = roomCollection.Count + 1;
                    if (calculatedRoomId > 1)
                    {
                        foreach (Room r in roomCollection)
                        {
                            if (r.RoomID >= calculatedRoomId)
                            {
                                calculatedRoomId = r.RoomID + 1;
                            }
                        }
                    }

                    string[] roomArgs = new string[6];
                    roomArgs[(int)CustomTypes.enRoom.name] = calculatedRoomId.ToString();
                    roomArgs[(int)CustomTypes.enRoom.beds] = "0";
                    roomArgs[(int)CustomTypes.enRoom.note] = "Beállításra vár";
                    roomCollection.Add(new Room(calculatedRoomId, houseToAdd, roomArgs));
                }
            }
            else if (argHandleMethod == CustomTypes.enObjAddType.LOAD)
            {
                houseToAdd = new House(int.Parse(argFileds[(int)CustomTypes.enHouse.houseId]), argFileds);
                houseCollection.Add(houseToAdd);
            }
            else
            {
                //Error
            }
            return houseToAdd;
        }

        public static Room AddRoom(string[] argFields, CustomTypes.enObjAddType argHandleMethod)
        {
            Room roomToAdd = null;

            if (argHandleMethod == CustomTypes.enObjAddType.LOAD)
            {
                House houseToLoad = null;
                foreach (House h in houseCollection)
                {
                    if (h.HouseID == int.Parse(argFields[(int)CustomTypes.enRoom.houseId]))
                    {
                        houseToLoad = h;
                        break;
                    }
                }

                roomToAdd = new Room(int.Parse(argFields[(int)CustomTypes.enRoom.roomId]), houseToLoad, argFields);

                foreach (Reservation res in reservationCollection)
                {
                    if (int.Parse(argFields[(int)CustomTypes.enReservation.resId]) == res.ReservationId)
                    {
                        res.ItsRoom = roomToAdd;
                    }
                }

                roomCollection.Add(roomToAdd);
            }
            else if (argHandleMethod == CustomTypes.enObjAddType.CREATE)
            {
                //TODO: Create implementation
            }
            else
            {
                //Error
            }

            return roomToAdd;
        }

        public static Guest AddGuest(string[] argFields, CustomTypes.enObjAddType argHandleMethod)
        {
            Guest guestToAdd = null;

            if (argHandleMethod == CustomTypes.enObjAddType.LOAD)
            {
                guestToAdd = new Guest(int.Parse(argFields[(int)CustomTypes.enGuest.guestId]), argFields);          
                guestCollection.Add(guestToAdd);
            }
            else if (argHandleMethod == CustomTypes.enObjAddType.CREATE)
            {
                int calculatedGuestId = 1;
                if (guestCollection.Count != 0)
                {
                    foreach (Guest g in guestCollection)
                    {
                        if (g.GuestId >= calculatedGuestId)
                        {
                            calculatedGuestId = g.GuestId + 1;
                        }
                    }
                }
                guestToAdd = new Guest(calculatedGuestId, argFields);
                guestCollection.Add(guestToAdd);            
            }
            else
            {
                //Error
            }
            return guestToAdd;
        }

        public static Reservation AddReservation(string[] argFields, CustomTypes.enObjAddType argHandleMethod)
        {
            Reservation resToAdd = null;
            Room roomOfRes = null;
            Guest guestOfRes = null;

            if (argHandleMethod == CustomTypes.enObjAddType.LOAD)
            {
                foreach (Room r in roomCollection)
                {
                    if (int.Parse(argFields[(int)CustomTypes.enReservation.roomId]) == r.RoomID)
                    {
                        roomOfRes = r;
                    }
                }

                foreach (Guest g in guestCollection)
                {
                    if (int.Parse(argFields[(int)CustomTypes.enReservation.guestId]) == g.GuestId)
                    {
                        guestOfRes = g;
                    }
                }


                resToAdd = new Reservation(int.Parse(argFields[(int)CustomTypes.enReservation.resId]), roomOfRes, guestOfRes, argFields);
                reservationCollection.Add(resToAdd);

            }
            else if (argHandleMethod == CustomTypes.enObjAddType.CREATE)
            {
                int calculatedReservationId = 1;
                if (reservationCollection.Count != 0)
                {
                    foreach (Reservation r in reservationCollection)
                    {
                        if (r.ReservationId >= calculatedReservationId)
                        {
                            calculatedReservationId = r.ReservationId + 1;
                        }
                    }
                }

                foreach (Room r in roomCollection)
                {
                    if (int.Parse(argFields[(int)CustomTypes.enReservation.roomId]) == r.RoomID)
                    {
                        roomOfRes = r;
                    }
                }

                foreach (Guest g in guestCollection)
                {
                    if (int.Parse(argFields[(int)CustomTypes.enReservation.guestId]) == g.GuestId)
                    {
                        guestOfRes = g;
                    }
                }
                resToAdd = new Reservation(calculatedReservationId, roomOfRes, guestOfRes, argFields);
                reservationCollection.Add(resToAdd);
            }
            else
            {
                //Error
            }


            return resToAdd;
        }




    }
}
