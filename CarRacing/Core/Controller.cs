﻿using CarRacing.Core.Contracts;
using CarRacing.Models.Cars;
using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Maps;
using CarRacing.Models.Maps.Contracts;
using CarRacing.Models.Racers;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Core
{
    public class Controller : IController
    {

        private CarRepository cars;
        private RacerRepository racers;
        private IMap map;

        public Controller()
        {
            cars = new CarRepository();
            racers = new RacerRepository();
            map = new Map();
        }

        public string AddCar(string type, string make, string model, string VIN, int horsePower)
        {
            if (type == "SuperCar")
            {
                ICar car = new SuperCar(make, model, VIN, horsePower);
                cars.Add(car);
                return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
            }
            else if (type == "TunedCar")
            {
                ICar car = new TunedCar(make, model, VIN, horsePower);
                cars.Add(car);
                return String.Format(OutputMessages.SuccessfullyAddedCar, make, model, VIN);
            }
            else
            {
                return ExceptionMessages.InvalidCarType;
            }
        }

        public string AddRacer(string type, string username, string carVIN)
        {
            if(cars.Models.FirstOrDefault(c => c.VIN == carVIN) == null)
            {
                return ExceptionMessages.CarCannotBeFound;
            }

            if(type == "ProfessionalRacer")
            {
                IRacer racer = new ProfessionalRacer(username, cars.Models.First(c => c.VIN == carVIN));
                racers.Add(racer);
                return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
            }
            else if (type == "StreetRacer")
            {
                IRacer racer = new StreetRacer(username, cars.Models.First(c => c.VIN == carVIN));
                racers.Add(racer);
                return String.Format(OutputMessages.SuccessfullyAddedRacer, username);
            }
            else { return ExceptionMessages.InvalidRacerType; }
        }

        public string BeginRace(string racerOneUsername, string racerTwoUsername)
        {
            var racer1 = this.racers.FindBy(racerOneUsername);
            if (racer1 == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername));
            }

            var racer2 = this.racers.FindBy(racerTwoUsername);
            if (racer2 == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername));
            }

            return this.map.StartRace(racer1, racer2);

        }

        public string Report()
        {
            var orderedRacers = racers.Models.OrderBy(r => r.Username).OrderByDescending(r => r.DrivingExperience);

            StringBuilder sb = new StringBuilder(); 

            foreach (var racer in orderedRacers)
            {
                sb.AppendLine(racer.ToString());
                sb.AppendLine();
            }

            return sb.ToString().Trim();
        }
    }
}
