using CarRacing.Models.Cars.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Racers
{
    public class ProfessionalRacer : Racer
    {
        private const int _drivingExperience = 30;
        private const string _racingBehavior = "strict"; 
        public ProfessionalRacer(string username, ICar car) 
            : base(username, _racingBehavior, _drivingExperience, car)
        {
        }
    }
}
