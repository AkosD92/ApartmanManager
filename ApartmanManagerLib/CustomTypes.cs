using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanManagerLib
{
    public static class CustomTypes
    {

        public enum enPayMethod { KARTYA, KESZPENZ, SZ_OTP, SZ_MKB, SZ_KNH };

        public enum enAppState {STARTUP, RUNNING, CLOSING, ERROR};

        public enum enSubject {HOUSE, GUEST, ROOM, RESERVATION, ARCHIVEGUEST };

        public const int SUCCESS = 0;
        public const int FAILURE = -1;

        public const int IFA = 400;

        
        

    }
}
