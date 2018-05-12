using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ApartmanManagerLib
{


    /*This class is a statemachine containing states that controls the application life-cycle
     
         States:
                      1. Init state:    - Create instance manager with loaded data from storage file (counters for IDs)
                                    
         
         
         
         */
    public static class ProgramFlow
    {
        public static CustomTypes.enAppState appState = CustomTypes.enAppState.STARTUP;
        public static bool IsLoggedIn = false;

        public static StorageManager_File StorageManager = new StorageManager_File();



        public static void StartUp()
        {

            StorageManager.StartUpRecover();
   

            
        }

        public static void ExitSave()
        {
            if ((appState == CustomTypes.enAppState.RUNNING) && (IsLoggedIn == true))
            {
                StorageManager.SaveOnExit();
            }
        }


        


    }
}
