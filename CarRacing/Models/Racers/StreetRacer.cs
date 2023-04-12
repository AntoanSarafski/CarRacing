using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class StreetRacer : Racer
    {
        private const int _drivingExperience = 10;
        private const string _racingBehavior = "agressive";
        public StreetRacer(string username, ICar car)
            : base(username, _racingBehavior, _drivingExperience, car)
        {
        }
    }
}
