using CarRacing.Core.Contracts;
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
            if(racers.Models.FirstOrDefault(r => r.Username == racerOneUsername) == null)
            {
                return String.Format(ExceptionMessages.RacerCannotBeFound, racerOneUsername);
            }
            else if (racers.Models.FirstOrDefault(r => r.Username == racerTwoUsername) == null)
            {
                return String.Format(ExceptionMessages.RacerCannotBeFound, racerTwoUsername);
            }
            else
            {
                ICar firstCar;
                IRacer firstRacer;
                ICar secondCar;
                IRacer secondRacer;

                if (racers.Models.First(r => r.Username == racerOneUsername).RacingBehavior == "agressive")
                {
                    if (racers.Models.First(r => r.Username == racerOneUsername).Car.GetType().Name == "SuperCar")
                    {
                        firstCar = new SuperCar(racers.Models.First(r => r.Username == racerOneUsername).Car.Make,
                            racers.Models.First(r => r.Username == racerOneUsername).Car.Model,
                             racers.Models.First(r => r.Username == racerOneUsername).Car.VIN,
                              racers.Models.First(r => r.Username == racerOneUsername).Car.HorsePower);

                        firstRacer = new StreetRacer(racerOneUsername, firstCar);
                    }
                    else
                    {
                        firstCar = new TunedCar(racers.Models.First(r => r.Username == racerOneUsername).Car.Make,
                            racers.Models.First(r => r.Username == racerOneUsername).Car.Model,
                             racers.Models.First(r => r.Username == racerOneUsername).Car.VIN,
                              racers.Models.First(r => r.Username == racerOneUsername).Car.HorsePower);

                        firstRacer = new StreetRacer(racerOneUsername, firstCar);
                    }
                }
                else
                {
                    if (racers.Models.First(r => r.Username == racerOneUsername).Car.GetType().Name == "SuperCar")
                    {
                        firstCar = new SuperCar(racers.Models.First(r => r.Username == racerOneUsername).Car.Make,
                            racers.Models.First(r => r.Username == racerOneUsername).Car.Model,
                             racers.Models.First(r => r.Username == racerOneUsername).Car.VIN,
                              racers.Models.First(r => r.Username == racerOneUsername).Car.HorsePower);

                        firstRacer = new ProfessionalRacer(racerOneUsername, firstCar);
                    }
                    else
                    {
                        firstCar = new TunedCar(racers.Models.First(r => r.Username == racerOneUsername).Car.Make,
                            racers.Models.First(r => r.Username == racerOneUsername).Car.Model,
                             racers.Models.First(r => r.Username == racerOneUsername).Car.VIN,
                              racers.Models.First(r => r.Username == racerOneUsername).Car.HorsePower);

                        firstRacer = new ProfessionalRacer(racerOneUsername, firstCar);
                    }
                }

                if (racers.Models.First(r => r.Username == racerTwoUsername).RacingBehavior == "agressive")
                {
                    if (racers.Models.First(r => r.Username == racerTwoUsername).Car.GetType().Name == "SuperCar")
                    {
                        secondCar = new SuperCar(racers.Models.First(r => r.Username == racerTwoUsername).Car.Make,
                            racers.Models.First(r => r.Username == racerTwoUsername).Car.Model,
                             racers.Models.First(r => r.Username == racerTwoUsername).Car.VIN,
                              racers.Models.First(r => r.Username == racerTwoUsername).Car.HorsePower);

                        secondRacer = new StreetRacer(racerTwoUsername, secondCar);
                    }
                    else
                    {
                        secondCar = new TunedCar(racers.Models.First(r => r.Username == racerTwoUsername).Car.Make,
                            racers.Models.First(r => r.Username == racerTwoUsername).Car.Model,
                             racers.Models.First(r => r.Username == racerTwoUsername).Car.VIN,
                              racers.Models.First(r => r.Username == racerTwoUsername).Car.HorsePower);

                        secondRacer = new StreetRacer(racerTwoUsername, secondCar);
                    }
                }
                else
                {
                    if (racers.Models.First(r => r.Username == racerTwoUsername).Car.GetType().Name == "SuperCar")
                    {
                        secondCar = new SuperCar(racers.Models.First(r => r.Username == racerTwoUsername).Car.Make,
                            racers.Models.First(r => r.Username == racerTwoUsername).Car.Model,
                             racers.Models.First(r => r.Username == racerTwoUsername).Car.VIN,
                              racers.Models.First(r => r.Username == racerTwoUsername).Car.HorsePower);

                        secondRacer = new ProfessionalRacer(racerTwoUsername, secondCar);
                    }
                    else
                    {
                        secondCar = new TunedCar(racers.Models.First(r => r.Username == racerTwoUsername).Car.Make,
                            racers.Models.First(r => r.Username == racerTwoUsername).Car.Model,
                             racers.Models.First(r => r.Username == racerTwoUsername).Car.VIN,
                              racers.Models.First(r => r.Username == racerTwoUsername).Car.HorsePower);

                        secondRacer = new ProfessionalRacer(racerTwoUsername, secondCar);
                    }
                }


                return map.StartRace(firstRacer, secondRacer);
            }

        }

        public string Report()
        {

        }
    }
}
