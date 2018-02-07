using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanManagerLib
{
    public interface IStorageManager
    {


        void StartUpRecover();
        void SaveOnExit();


    }
}
