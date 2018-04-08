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

        public enum enSubject {HOUSE, GUEST, ROOM, RESERVATION };

        public enum enObjAddType { CREATE, LOAD};

        public enum enHouse
        {
            houseId = 0,
            name = 1,
            rooms = 2,
            note = 3
        }

        public enum enRoom
        {
            roomId = 0,
            resId = 1,
            houseId = 2,
            name = 3,
            beds = 4,
            note = 5
        }

        public enum enReservation
        {
            resId = 0,
            arrival = 1,
            leave = 2,
            persons = 3,
            infants = 4,
            paytype = 5,
            cost = 6,
            prepaid = 7,
            remainder = 8,
            note = 9
        }

        public enum enGuest
        {
            guestId = 0,
            resId = 1,
            familyname = 2,
            firstname = 3,
            tel = 4,
            address = 5,
            mail = 6,
            note = 7
        }

        public const int SUCCESS = 0;
        public const int FAILURE = -1;

        public const int IFA = 400;

        
        

    }
}
