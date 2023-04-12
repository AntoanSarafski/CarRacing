using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public abstract class Racer : IRacer
    {
        private string username;
        private string racingBehavior;
        private int drivingExperience;
        private ICar car;

        public string Username 
        { 
            get => username;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerName);
                }
                username = value;
            }
        }

        public string RacingBehavior 
        {
            get => racingBehavior;
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerBehavior);
                }
                racingBehavior = value;
            }
        }

        public int DrivingExperience 
        { 
            get => drivingExperience;
            private set
            {
                if(value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerDrivingExperience);
                }
                drivingExperience = value;
            }
        }

        public ICar Car 
        { 
            get => car;
            private set
            {
                if(car == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidRacerCar);
                }
                car = value;
            } 
        }

        public bool IsAvailable()
        {
            // TODO
            throw new NotImplementedException();
        }

        public void Race()
        {
            // TODO
            throw new NotImplementedException();
        }
    }
}
