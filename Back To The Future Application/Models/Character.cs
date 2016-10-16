using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Future_Application
{
    /// <summary>
    /// base class for the player and all game characters
    /// </summary>
    public class Character
    {
        #region ENUMERABLES

        public enum CharacterType
        {
            None,
            Doc, 
            Marty, 
            Einstein,
        }

        #endregion

        #region FIELDS

        private string _name;
        private int _yearLocationID;
        private CharacterType _character;

        public CharacterType Characters
        {
            get { return _character; }
            set { _character = value; }
        }


        public int YearLocationID
        {
            get { return _yearLocationID; }
            set { _yearLocationID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
         #endregion


        #region PROPERTIES



        #endregion


        #region CONSTRUCTORS

        public Character()
        {

        }

        public Character(string name, CharacterType character, int yearLocationID)
        {
            _name = name;
            _character = character;
            _yearLocationID = yearLocationID;
        }
        #endregion


        #region METHODS



        #endregion




    }
}
