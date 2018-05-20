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
        public static ObservableCollection<Day> days = new ObservableCollection<Day>();


        public static void InitDays()
        {
            for (int i = 0; i < 31; i++)
            {
                days.Add(new Day());
            }
        }

        public static void CleanOwners()
        {
            if (days.Count != 0)
            {
                for (int i = 0; i < 31; i++)
                {
                    days.ElementAt(i).Owner = "";
                    days.ElementAt(i).Color = "White";
                }

            }
        }

        public static void UpdateDays(DateTime argMonth, int argDays, Room argRoom)
        {
            CleanOwners();
           
            ObservableCollection<Reservation> relevantRes = new ObservableCollection<Reservation>();

            DateTime lastDay = argMonth.AddDays(argDays);
            foreach (Reservation res in InstanceManager.reservationCollection)
            {
                if ((res.ItsRoom == argRoom) && ((res.Arrival >= argMonth) || (res.Leave <= lastDay)))
                {
                    relevantRes.Add(res);
                }
            }


            for (int i = 0; i < argDays; i++)
            {
                foreach (Reservation res in relevantRes)
                {
                    if ((res.Arrival <= argMonth) && (res.Leave >= argMonth))
                    {
                        days.ElementAt(i).ItsGuest = res.ItsGuest;
                        days.ElementAt(i).Owner = res.ItsGuest.FamilyName.ToString() + " " + res.ItsGuest.FirstName.ToString();
                        days.ElementAt(i).Color = "DeepSkyBlue";
                    }
                    
                }
                argMonth = argMonth.AddDays(1);
            }

        }

        public static void UpdateAvailableRooms(DateTime argArrival, DateTime argLeave, House argHouse)
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
