using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ApartmanManagerLib
{
    public class Day : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void pNotify([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private Guest itsGuest;
        private string owner;
        private string comment;
        private string color;


        public Guest ItsGuest { get { return itsGuest; } set { itsGuest = value; pNotify(); } }
        public string Comment { get { return comment; } set { comment = value; pNotify(); } }
        public string Owner { get { return owner.ToString(); } set { owner = value; pNotify(); } }
        public string Color { get { return color.ToString(); } set { color = value; pNotify(); } }

        public Day()
        {
            itsGuest = null;
            comment = "";
            owner = "";
            color = "White";
        }

        public Day(Guest argItsGuest)
        {
            itsGuest = argItsGuest;
            comment = "";
            owner = "";
        }

        public Day(string name)
        {
            itsGuest = null;
            comment = "";
            owner = name;
        }

    }
}
