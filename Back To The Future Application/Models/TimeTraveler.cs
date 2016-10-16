using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Future_Application
{
    public class Traveler : Character
    {
        #region FIELDS

        private int _age;

       


        #endregion


        #region PROPERTIES

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }

        #endregion


        #region CONSTRUCTORS

        public Traveler()
        {

        }
        public Traveler(string name, CharacterType character, int yearLocationID, int age) : base(name, character, yearLocationID)
        {
            _age = Age;
        }

        #endregion


        #region METHODS



        #endregion
    }
}
