using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanManagerLib
{
    public static class CalendarManager
    {
        public static ObservableCollection<Room> availableRooms = new ObservableCollection<Room>();




        public static void updateAvailableRooms(DateTime argArrival, DateTime argLeave, House argHouse)
        {
            availableRooms.Clear();
        
            foreach (Room r in InstanceManager.roomCollection)
            {
                if (r.ItsHouse == argHouse)
                {
                    foreach (Reservation res in InstanceManager.reservationCollection)
                    {
                        if (res.ItsRoom == r)
                        {
                            if ((argLeave <= res.Arrival) || (argArrival >= res.Leave))
                            {
                                availableRooms.Add(r);
                            }

                        }
                        else
                        {
                            availableRooms.Add(r);
                        }
                        
                    }
                    if (InstanceManager.reservationCollection.Count == 0)
                    {
                        availableRooms.Add(r);
                    }
                }
            }
            
        }

    }
}
