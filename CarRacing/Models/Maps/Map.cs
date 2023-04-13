using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Maps
{
    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            

            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable()) 
            {
                return OutputMessages.RaceCannotBeCompleted;
            }

            if (!racerOne.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
                
            }

            if (!racerTwo.IsAvailable())
            {
                return String.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }

            

            else 
            {
                racerOne.Race();
                racerTwo.Race();

                double firstRacerChanceOfWin = racerOne.Car.HorsePower * racerOne.DrivingExperience;
                if (racerOne.RacingBehavior == "agressive" )
                {
                    firstRacerChanceOfWin *= 1.1;
                }
                else { firstRacerChanceOfWin *= 1.2; }

                double secondRacerChanceOfWin = racerTwo.Car.HorsePower * racerTwo.DrivingExperience;
                if (racerTwo.RacingBehavior == "agressive")
                {
                    secondRacerChanceOfWin *= 1.1;
                }
                else { secondRacerChanceOfWin *= 1.2; }

                IRacer winner;

                if (firstRacerChanceOfWin > secondRacerChanceOfWin)
                {
                    winner = racerOne;
                }
                else
                {
                    winner = racerTwo;
                }

                return String.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
            }
        }
    }
}
