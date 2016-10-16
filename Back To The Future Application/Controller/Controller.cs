using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back_To_The_Future_Application
{
    public class Controller
    {
        #region FIELDS

        private bool _usingGame;
        bool _missionInitialized = false;
        private ConsoleView _gameConsoleView;
        private Traveler _gameTraveler;
        private Future _gameFuture;

        //
        // declare all objects required for the game
        // Note - these field objects do not require properties since they
        //        are not accessed outside of the controller
        //

        #endregion

        #region PROPERTIES


        #endregion


        #region CONSTRUCTORS

        public Controller()
        {
            InitializeGame();
            //
            // begins running the application UI
            //

            ManageGameLoop();
        }

        #endregion


        #region METHODS

        /// <summary>
        /// initialize the game 
        /// </summary>
        private void InitializeGame()
        {
            _usingGame = true;
            //
            // instantiate a Traveler object
            //
            _gameFuture = new Future();
            _gameTraveler = new Traveler();
            //
            // instantiate a ConsoleView object
            //
            _gameConsoleView = new ConsoleView(_gameTraveler, _gameFuture);
            InitializeTimeTravel();
        }

        /// <summary>
        /// method to manage the application setup and control loop
        /// </summary>
        private void ManageGameLoop()
        {
            TravelerAction travelerActionChoice;

            _gameConsoleView.DisplayWelcomeScreen();

            InitializeMission();

            //
            // game loop
            //
            _usingGame = true;
            while (_usingGame)
            {

                //
                // get a menu choice from the ConsoleView object
                //
                travelerActionChoice = _gameConsoleView.DisplayGetTravelerActionChoice();

                //
                // choose an action based on the user's menu choice
                //
                switch (travelerActionChoice)
                {
                    case TravelerAction.None:
                        break;
                    case TravelerAction.LookAround:
                        _gameConsoleView.DisplayLookAround();
                        break;
                    case TravelerAction.Travel:
                        _gameTraveler.YearLocationID = _gameConsoleView.DisplayGetTravelersNewYear().YearLocationID;
                        break;
                    case TravelerAction.ListYearDestinations:
                        _gameConsoleView.DisplayListAllYearDestinations();
                        break;
                    case TravelerAction.TravlerInfo:
                        _gameConsoleView.DisplayTravelerInfo();
                        break;
                    case TravelerAction.Exit:
                        _usingGame = false;
                        break;
                    default:
                        break;
                }
            }

            _gameConsoleView.DisplayExitPrompt();

            //
            // close the application
            //
            Environment.Exit(1);
        }

        /// <summary>
        /// initialize the traveler's starting traveling  parameters
        /// </summary>
        private void InitializeMission()
        {
            if (!_missionInitialized)
            {
                _gameConsoleView.DisplayTimeTravelerSetupIntro();
                _gameTraveler.Name = _gameConsoleView.DisplayGetTravelersName();
                _gameTraveler.Characters = _gameConsoleView.DisplayGetTravelersCharacter();
                _gameTraveler.YearLocationID = _gameConsoleView.DisplayGetTravelersNewYear().YearLocationID;
                _missionInitialized = true;
            }
        }

        /// <summary>
        /// initialize the future with all of the year locations
        /// </summary>
        private void InitializeTimeTravel()
        {
            _gameFuture.YearLocations.Add(new YearLocation
            {
                Year = "1955",
                YearLocationID = 1,
                Description = "The year is 1955, a time where you went to the drive in, a sock hop, and steady. " +
                              "You just arrived at the Enchantment of Sea dance and who would have ever thought 1955 could have been this fun." +
                              "You just realized that you left your photo of your family in another year",
                Accessable = true
            });

            _gameFuture.YearLocations.Add(new YearLocation
            {
                Year = "1985",
                YearLocationID = 2,
                Description = "The year is 1985, a time where everything is neon and radical " +
                              "You just walked into the door of your house and are so glad to be home. " +
                              "Then you realize that you left your walkman in another year.",
                Accessable = false
            });

            _gameFuture.YearLocations.Add(new YearLocation
            {
                Year = "2015",
                YearLocationID = 3,
                Description = "The year is 2015, thought to be a time of flying cars and hoverboards. " +
                  "You arrive in 2015 looking to see the Chicago Cubs winning the world series, " +
                  "then you realize that you left your sports almanac in another year.",
                Accessable = true
            });
            _gameFuture.YearLocations.Add(new YearLocation
            {
                Year = "1885",
                YearLocationID = 4,
                Description = "The year is 1885, a time where a good time included whiskey and a gun. " +
                              "You just arrived at the Good Ole Saloon and sit down for a drink. " +
                              "Then you realize that you left your colt 45 in another year.",
                Accessable = true
            });
        }

        #endregion
    }
}
