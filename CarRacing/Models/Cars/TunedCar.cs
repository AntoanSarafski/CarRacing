using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        private const int _fuelAvailable = 65;
        private const double _fuelConsumptionPerRace = 7.5;
        public TunedCar(string make, string model, string vIN, int horsePower)
            : base(make, model, vIN, horsePower, _fuelAvailable, _fuelConsumptionPerRace)
        {

            
        }

        public override sealed void Drive()
        {
            FuelAvailable -= FuelConsumptionPerRace;
            HorsePower -= (int)Math.Round(HorsePower * 0.03);
        }
    }
}
