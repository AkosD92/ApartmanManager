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
            houseId = 1,
            name = 2,
            beds = 3,
            note = 4
        }

        public enum enReservation
        {
            resId = 0,
            roomId = 1,
            guestId = 2,
            arrival = 3,
            leave = 4,
            persons = 5,
            infants = 6,
            paytype = 7,
            cost = 8,
            prepaid = 9,
            remainder = 10,
            note = 11
        }

        public enum enGuest
        {
            guestId = 0,
            familyname = 1,
            firstname = 2,
            tel = 3,
            address = 4,
            mail = 5,
            note = 6
        }

        public const int SUCCESS = 0;
        public const int FAILURE = -1;

        public const int IFA = 400;

        
        

    }
}
