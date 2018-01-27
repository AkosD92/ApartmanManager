﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ApartmanManagerLib
{
    public class StorageManager_File : IStorageManager
    {
        public static string houseDbPath = @"..\..\Data\dbHouse.adb";
        public static string roomDbPath = @"..\..\Data\dbRoom.adb";

        public int SaveOnExit()
        {
            System.IO.File.WriteAllText(houseDbPath, String.Empty);
            System.IO.File.WriteAllText(roomDbPath, String.Empty);

            foreach (House h in InstanceManager.houseCollection)
            {
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(houseDbPath, true))
                    {
                        file.WriteLine(h.ToString());
                    }
                }
                catch (System.IO.IOException)
                {
                    return CustomTypes.FAILURE;
                }
            }

            foreach (Room r in InstanceManager.roomCollection)
            {
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(roomDbPath, true))
                    {
                        file.WriteLine(r.ToString());
                    }
                }
                catch (System.IO.IOException)
                {
                    return CustomTypes.FAILURE;
                }
            }

            return CustomTypes.SUCCESS;
        }


        public int StartUpRecover()
        {
            string line;
            string[] fields;
            int instanceCount = 0;

            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(houseDbPath);
                while ((line = file.ReadLine()) != null)
                {
                    fields = line.Split('|');
                    InstanceManager.LoadHouse(fields[0], fields[1], fields[2], fields[3]);
                    if ((int.Parse(fields[0])) > instanceCount)
                    {
                        instanceCount = int.Parse(fields[0]);
                    }
                }
                file.Close();
            }
            catch (System.IO.IOException)
            {
                return CustomTypes.FAILURE;
            }

            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(roomDbPath);
                while ((line = file.ReadLine()) != null)
                {
                    fields = line.Split('|');
                    InstanceManager.LoadRoom(fields[0], fields[1], fields[2], fields[3], fields[4], fields[5]);
                    if ((int.Parse(fields[0])) > instanceCount)
                    {
                        instanceCount = int.Parse(fields[0]);
                    }
                }
                file.Close();
            }
            catch (System.IO.IOException)
            {
                return CustomTypes.FAILURE;
            }

            return CustomTypes.SUCCESS;
        }
    }
}