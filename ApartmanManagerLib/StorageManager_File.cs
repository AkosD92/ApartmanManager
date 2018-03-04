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
        public static string archiveGuestDbPath = @"..\..\Data\dbGuest.adb";
        public static string activeGuestDbPath = @"..\..\Data\dbActiveGuest.adb";

        public void SaveOnExit()
        {
            System.IO.File.WriteAllText(houseDbPath, String.Empty);
            System.IO.File.WriteAllText(roomDbPath, String.Empty);
            System.IO.File.WriteAllText(archiveGuestDbPath, String.Empty);
            System.IO.File.WriteAllText(activeGuestDbPath, String.Empty);

            WriteObjects(CustomTypes.enSubject.HOUSE, InstanceManager.houseCollection, houseDbPath);
            WriteObjects(CustomTypes.enSubject.ROOM, InstanceManager.roomCollection, roomDbPath);
            WriteObjects(CustomTypes.enSubject.GUEST, InstanceManager.archiveGuestCollection, archiveGuestDbPath);
            WriteObjects(CustomTypes.enSubject.GUEST, InstanceManager.activeGuestCollection, activeGuestDbPath);

        }

        public void StartUpRecover()
        {
            ReadObjects(CustomTypes.enSubject.HOUSE, houseDbPath);
            ReadObjects(CustomTypes.enSubject.ROOM, roomDbPath);
            ReadObjects(CustomTypes.enSubject.GUEST, archiveGuestDbPath);
            ReadObjects(CustomTypes.enSubject.GUEST, activeGuestDbPath);
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
                    fields = line.Split('|');
                    if (subject == CustomTypes.enSubject.HOUSE)
                    {
                        InstanceManager.LoadHouse(fields[0], fields[1], fields[2], fields[3]);
                    }
                    else if (subject == CustomTypes.enSubject.ROOM)
                    {
                        InstanceManager.LoadRoom(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5]);
                    }
                    else if (subject == CustomTypes.enSubject.GUEST)
                    {
                        InstanceManager.LoadArchiveGuest(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5], fields[6], fields[7]);
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
