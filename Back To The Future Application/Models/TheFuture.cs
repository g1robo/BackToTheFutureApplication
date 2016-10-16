using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Future_Application
{
    #region
    // lists within the Future object
    public class Future
    {
        // list year locations
        public List<YearLocation> YearLocations { get; set; }
        // list items
        
     #endregion 

        #region constructor
        public Future()
        {
            // initiate year and items
            YearLocations = new List<YearLocation>();
            
            // add all years and items
            
        }
        #endregion
        #region methods
        public YearLocation GetYearLocationByID(int ID)
        {
            YearLocation spl = null;
            // cycle through year locations and return selected

            foreach (YearLocation location in YearLocations)
            {
                if (location.YearLocationID == ID)
                {
                    spl = location;
                }
            }
            // ID was not found in the Future
            if (spl == null)
            {
                ConsoleUtil.DisplayMessage( $" The Year Location ID {ID} does not exist in the Future.");
                
            }
            return spl;
        }
    }
}

#endregion