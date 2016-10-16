using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Future_Application
{
    public class YearLocation
    {
        #region FIELDS
        private string _year;
        private int _yearLocationID;
        private string _description;
        private bool _accessable;

        public bool Accessable
        {
            get { return _accessable; }
            set { _accessable = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public int YearLocationID
        {
            get { return _yearLocationID; }
            set { _yearLocationID = value; }
        }

        public string Year
        {
            get { return _year; }
            set { _year = value; }
        }

       


        #endregion


        #region PROPERTIES



        #endregion


        #region CONSTRUCTORS
       


        #endregion


        #region METHODS



        #endregion


    }
}
