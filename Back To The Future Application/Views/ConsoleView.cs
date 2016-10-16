using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Future_Application
{
    /// <summary>
    /// Console class for the MVC pattern
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS

        //
        // declare a Future and Traveler object for the ConsoleView object to use
        //
        Future _gameFuture;
        Traveler _gamePlayer;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Traveler gamePlayer, Future gameFuture)
        {
            _gamePlayer = gamePlayer;
            _gameFuture = gameFuture;
            
                     
            InitializeConsole();
        }

        #endregion

        #region METHODS

        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "- Robemaps -";
            ConsoleUtil.HeaderText = "- Back to the Future -";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;

            Console.WriteLine();

            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();

            Console.WriteLine();

            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.HeaderText = "Exit";
            ConsoleUtil.DisplayReset();

            Console.CursorVisible = false;

            Console.WriteLine();
            ConsoleUtil.DisplayMessage(" Great Scott!");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage(" Are you sure you want to leave the Future?");
            DisplayContinuePrompt();
            Console.ReadKey();

            System.Environment.Exit(1);
        }


        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();

            ConsoleUtil.DisplayReset();

            ConsoleUtil.DisplayMessage("- Back to the Future Application-");
            ConsoleUtil.DisplayMessage("");
            Console.WriteLine();


            sb.Clear();
            sb.AppendFormat("- You have just realized that the Flux Capacitor really does work!  -");
            sb.AppendFormat("- You now can drive or fly the DeLorean throughout time.  -");
            sb.AppendFormat("- Visit a destination year and see where the Future takes you -");
            ConsoleUtil.DisplayMessage(sb.ToString());
            Console.WriteLine();
            sb.Clear();
            ConsoleUtil.DisplayMessage(sb.ToString());

            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new Traveler object
        /// </summary>
        public void DisplayTimeTravelerSetupIntro()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Time Traveler Setup";
            ConsoleUtil.DisplayReset();


            ConsoleUtil.DisplayMessage("You will now be prompted to enter your personal information to start your time travels.");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a message confirming mission setup
        /// </summary>
        public void DisplayTimeTravelerSetupConfirmation()
        {
            //
            // display header
            //
            ConsoleUtil.HeaderText = "Time Traveler Setup";
            ConsoleUtil.DisplayReset();

            //
            // display confirmation
            //

            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("Your time travel info is complete.");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage("To view your information use the Main Menu.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get player's name
        /// </summary>
        /// <returns>name as a string</returns>
        public string DisplayGetTravelersName()
        {
            string travelersName;

            //
            // display header
            //
            ConsoleUtil.HeaderText = "Time Traveler's Name and Age";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayPromptMessage("Enter your Name: ");
            travelersName = Console.ReadLine();
            _gamePlayer.Age = DisplayGetInteger(1, 130, "Enter your Age: ");
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($"You have indicated {travelersName} as your name and you are {_gamePlayer.Age} years old.");

            DisplayContinuePrompt();

            return travelersName;
        }
        private int DisplayGetInteger(int min, int max, string prompt)
        {
            int integer = 0;

            bool validAge = false;

            while (!validAge)
            {
                ConsoleUtil.DisplayPromptMessage(prompt);
                if (int.TryParse(Console.ReadLine(), out integer))
                {
                    if (integer > min && integer < max)
                    {
                        validAge = true;
                    }
                    else
                    {
                        Console.WriteLine("Thats not within the range! Try Again");
                        DisplayContinuePrompt();
                    }
                }
                else
                {
                    Console.WriteLine("That's not an integer!");
                    DisplayContinuePrompt();
                }
            }

            return integer;
        }
        /// <summary>
        /// get and validate the player's character
        /// </summary>
        /// <returns>character as a CharacterType</returns>
        public Traveler.CharacterType DisplayGetTravelersCharacter()
        {
            bool validResponse = false;
            Traveler.CharacterType travelersCharacter = Traveler.CharacterType.None;

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = "Time Travelers Character";
                ConsoleUtil.DisplayReset();

                //
                // display all character types on a line
                //
                
                foreach (Character.CharacterType character in Enum.GetValues(typeof(Character.CharacterType)))
                {
                    if (character != Character.CharacterType.None)
                    {
                        ConsoleUtil.DisplayMessage(character.ToString());
                    }
                }
                ConsoleUtil.DisplayMessage("");
                ConsoleUtil.DisplayPromptMessage("Enter your character: ");
                
                //
                // validate user response for character
                //
                if (Enum.TryParse<Character.CharacterType>(Console.ReadLine(), out travelersCharacter))
                {
                    validResponse = true;
                    ConsoleUtil.DisplayReset();
                    ConsoleUtil.DisplayMessage($"You have indicated {travelersCharacter} as your character.");
                }
                else
                {
                    ConsoleUtil.DisplayMessage(" You are required to choose a character from the list above. ");
                    ConsoleUtil.DisplayMessage("Please re-enter a character from the list above.");
                }
                DisplayContinuePrompt();
            }

            return travelersCharacter;
        }

        /// <summary>
        /// get and validate the player's Year destination
        /// </summary>
        /// <returns>Space-Time Location object</returns>
        public YearLocation DisplayGetTravelersNewYear()
        {
            bool validResponse = false;
            int locationID;
            YearLocation nextYearTimeLocation = new YearLocation();

            while (!validResponse)
            {
                //
                // display header
                //
                ConsoleUtil.HeaderText = " Initialize Time Traveler Year Location";
                ConsoleUtil.DisplayReset();

                //
                // display a table of year locations
                //
                DisplayYearDestinationsTable();

                //
                // get and validate user's response for a year location
                //
                ConsoleUtil.DisplayPromptMessage("Choose the Year you want to travel to by entering the ID number: ");

                //
                // validate user's response for integer
                //
                if (int.TryParse(Console.ReadLine(), out locationID))
                {
                    ConsoleUtil.DisplayMessage("");

                    //
                    // validate user's response for range and accessible
                    //
                    try 
                    {
                        nextYearTimeLocation = _gameFuture.GetYearLocationByID(locationID);

                        ConsoleUtil.DisplayReset();
                        ConsoleUtil.DisplayMessage($"You have indicated {nextYearTimeLocation.Year} as the year.");
                        ConsoleUtil.DisplayMessage("");

                        if (nextYearTimeLocation.Accessable == true)
                        {
                            validResponse = true;
                            ConsoleUtil.DisplayMessage("You have reached 88 miles per hour in the DeLorean. Were off to the Future!");
                        }
                        else
                        {
                            ConsoleUtil.DisplayMessage("The Flux Capacitor is broke and you can't travel to this year at this time.");
                            ConsoleUtil.DisplayMessage("Please make another choice.");
                        }
                    }
                    //
                    // user's response was not in the correct range
                    //
                    catch (ArgumentOutOfRangeException ex)
                    {
                        ConsoleUtil.DisplayMessage("It appears you entered an invalid Year ID.");
                        ConsoleUtil.DisplayMessage(ex.Message);
                        ConsoleUtil.DisplayMessage("Please try again.");

                    }
                }
                //
                // user's response was not an integer
                //
                else
                {
                    ConsoleUtil.DisplayMessage("It appears you did not enter a number for the Year ID.");
                    ConsoleUtil.DisplayMessage("Please try again.");
                }

                DisplayContinuePrompt();
            }

            return nextYearTimeLocation;
        }

        /// <summary>
        /// generate a table of year locations and ids
        /// </summary>
        public void DisplayYearDestinationsTable()
        {
            int locationNumber = 1;

            //
            // table headings
            //
            ConsoleUtil.DisplayMessage("ID".PadRight(10) + "Year".PadRight(20));
            ConsoleUtil.DisplayMessage("---".PadRight(10) + "-------------".PadRight(20));

            //
            // location year and id
            //
            foreach (YearLocation location in _gameFuture.YearLocations)
            {
                ConsoleUtil.DisplayMessage(location.YearLocationID.ToString().PadRight(10) + location.Year.PadRight(20));
                locationNumber++;
            }
        }

        /// <summary>
        /// get the action choice from the user
        /// </summary>
        public TravelerAction DisplayGetTravelerActionChoice()
        {
            TravelerAction travelerActionChoice = TravelerAction.None;
            bool usingMenu = true;

            while (usingMenu)
            {
                //
                // set up display area
                //
                ConsoleUtil.HeaderText = " Time Traveler Actions";
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;

                //
                // display the menu
                //
                ConsoleUtil.DisplayMessage("Choose what you would like to do by choosing a number from the menu.");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "1. Look Around" + Environment.NewLine +
                    "\t" + "2. Travel" + Environment.NewLine +
                    "\t" + "3. Display All Years" + Environment.NewLine +
                    "\t" + "4. Display Traveler Info" + Environment.NewLine +
                    "\t" + "E. Exit" + Environment.NewLine);

                //
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                //
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        travelerActionChoice = TravelerAction.LookAround;
                        usingMenu = false;
                        break;
                    case '2':
                        travelerActionChoice = TravelerAction.Travel;
                        usingMenu = false;
                        break;
                    case '3':
                        travelerActionChoice = TravelerAction.ListYearDestinations;
                        usingMenu = false;
                        break;
                    case '4':
                        travelerActionChoice = TravelerAction.TravlerInfo;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        travelerActionChoice = TravelerAction.Exit;
                        usingMenu = false;
                        break;
                    default:
                        Console.WriteLine(
                            "It appears you have selected an incorrect choice." + Environment.NewLine +
                            "Press any key to continue or the ESC key to quit the application.");

                        userResponse = Console.ReadKey(true);
                        if (userResponse.Key == ConsoleKey.Escape)
                        {
                            usingMenu = false;
                        }
                        break;
                }
            }
            Console.CursorVisible = true;

            return travelerActionChoice;
        }

        /// <summary>
        /// display information about the current year location
        /// </summary>
        public void DisplayLookAround()
        {
            ConsoleUtil.HeaderText = "Current Year Information";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage(_gameFuture.GetYearLocationByID
                (_gamePlayer.YearLocationID).Description);

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of all Year destinations
        /// </summary>
        public void DisplayListAllYearDestinations()
        {
            ConsoleUtil.HeaderText = "Year Locations";
            ConsoleUtil.DisplayReset();
            DisplayYearDestinationsTable();

            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current traveler information
        /// </summary>
        public void DisplayTravelerInfo()
        {
            ConsoleUtil.HeaderText = " Time Traveler Information";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($" Time Traveler's Name:  {_gamePlayer.Name}");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage($" Time Traveler's Age:  {_gamePlayer.Age}");
            ConsoleUtil.DisplayMessage("");
            ConsoleUtil.DisplayMessage($" Time Traveler's Character:  {_gamePlayer.Characters}");
            ConsoleUtil.DisplayMessage("");
            string timeLocationName = _gameFuture.GetYearLocationByID
                (_gamePlayer.YearLocationID).Year;
            ConsoleUtil.DisplayMessage($" Time Traveler's Current Year:  {timeLocationName}");


            DisplayContinuePrompt();
        }

        #endregion
    }
}
