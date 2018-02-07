using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanManagerLib
{
    public static class CustomTypes
    {

        public enum enPayMethod { KARTYA, KESZPENZ, SZEP };
        public enum enSzepType { NEM, OTP, MKB, KNH };

        public enum enAppState {STARTUP, RUNNING, CLOSING, ERROR};

        public enum enSubject {HOUSE, GUEST, ROOM, RESERVATION };

        public const int SUCCESS = 0;
        public const int FAILURE = -1;
        

    }
}
