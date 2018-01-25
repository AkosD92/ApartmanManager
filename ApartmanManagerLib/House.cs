using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanManagerLib
{
    public class House
    {
        private int houseID;
        private string houseName;
        private byte numberOfRooms;
        private string note;

        public int HouseID
        {
            get { return houseID; }
            set { houseID = HouseID; }
        }

        public string HouseName
        {
            get { return houseName; }
            set { houseName = HouseName; }
        }

        public byte NumberOfRooms
        {
            get { return numberOfRooms; }
            set { numberOfRooms = NumberOfRooms; }
        }

        public string Note
        {
            get { return note; }
            set { note = Note; }
        }

        public House(int id, string name, byte nr, string note)
        {
            houseID = id;
            houseName = name;
            numberOfRooms = nr;
            this.note = note;
        }

        public override string ToString()
        {
            return houseID.ToString()+"|"+houseName+"|"+numberOfRooms.ToString()+"|"+this.note;
        }


    }
}
