using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ApartmanManagerLib
{
    public class StorageManager_File : IStorageManager
    {
        //File path specifications
        public static string houseDbPath = @"..\..\Data\dbHouse.adb";
        public static string roomDbPath = @"..\..\Data\dbRoom.adb";
        public static string GuestDbPath = @"..\..\Data\dbGuest.adb";
        public static string reservationDbPath = @"..\..\Data\dbReservation.adb";

        public void SaveOnExit()
        {
            System.IO.File.WriteAllText(houseDbPath, String.Empty);
            System.IO.File.WriteAllText(roomDbPath, String.Empty);
            System.IO.File.WriteAllText(GuestDbPath, String.Empty);
            System.IO.File.WriteAllText(reservationDbPath, String.Empty);

            WriteObjects(CustomTypes.enSubject.HOUSE, InstanceManager.houseCollection, houseDbPath);
            WriteObjects(CustomTypes.enSubject.ROOM, InstanceManager.roomCollection, roomDbPath);
            WriteObjects(CustomTypes.enSubject.GUEST, InstanceManager.guestCollection, GuestDbPath);
            WriteObjects(CustomTypes.enSubject.RESERVATION, InstanceManager.reservationCollection, reservationDbPath);

        }

        public void StartUpRecover()
        {
            ReadObjects(CustomTypes.enSubject.RESERVATION, reservationDbPath);
            ReadObjects(CustomTypes.enSubject.HOUSE, houseDbPath);
            ReadObjects(CustomTypes.enSubject.ROOM, roomDbPath);
            ReadObjects(CustomTypes.enSubject.GUEST, GuestDbPath);

        }

        private void WriteObjects<T>(CustomTypes.enSubject subject, ObservableCollection<T> collection, string path)
        {
            //subject is for further use

            foreach (T t in collection)
            {
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true))
                    {
                        file.WriteLine(t.ToString());
                    }
                }
                catch (System.IO.IOException)
                {

                }
            }
        }


        private void ReadObjects(CustomTypes.enSubject subject, string path)
        {
            string line;
            string[] fields;

            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    fields = line.Split(';');
                    if (subject == CustomTypes.enSubject.HOUSE)
                    {
                        InstanceManager.AddHouse(fields, CustomTypes.enObjAddType.LOAD);
                    }
                    else if (subject == CustomTypes.enSubject.ROOM)
                    {
                        InstanceManager.AddRoom(fields, CustomTypes.enObjAddType.LOAD);
                    }
                    else if (subject == CustomTypes.enSubject.GUEST)
                    {
                        InstanceManager.AddGuest(fields, CustomTypes.enObjAddType.LOAD);
                    }
                    else if (subject == CustomTypes.enSubject.RESERVATION)
                    {
                        InstanceManager.AddReservation(fields, CustomTypes.enObjAddType.LOAD);
                    }
                    else
                    {
                        //do nothing
                    }

                }
                file.Close();
            }
            catch (System.IO.IOException)
            {
               
            }
        }

       

    }

}
