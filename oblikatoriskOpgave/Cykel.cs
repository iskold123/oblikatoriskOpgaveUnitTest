using System;
using System.Collections.Generic;
using System.Text;

namespace oblikatoriskOpgave
{
    public class Cykel
    {
        #region Instanser

        private int _id;
        private string _color;
        private int _price;
        private int _gear;

        #endregion

        #region Property

        public int Id
        {
            get => _id;
            set => _id = value;
        }

        public string Color
        {
            get => _color;
            set
            {
                if (value.Length < 1) throw new ArgumentOutOfRangeException();
                _color = value;
            }
        }

        public int Price
        {
            get => _price;
            set
            {
                if (value < 0) throw new ArgumentNullException($"price cant be less then 0");
                _price = value;
            } 
    }

        public int Gear
        {
            get => _gear;
            set
            {
                if (value < 3 || value > 32 ) throw new ArgumentOutOfRangeException();
                _gear = value;
            }
        }

        #endregion

        #region Constructor

        public Cykel()
        {

        }

        public Cykel(int id, string color, int price, int gear)
        {
            _id = id;
            _color = color;
            _price = price;
            _gear = gear;
        }

        #endregion

        #region Metoder

        public override string ToString()
        {
            return "";
        }

        #endregion

    }
}
