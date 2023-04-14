using CarRacing.Models.Cars.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private readonly List<ICar> cars;

        public CarRepository()
        {
            cars = new List<ICar>();
        }
        public IReadOnlyCollection<ICar> Models => cars.AsReadOnly();

        public void Add(ICar car)
        {
            if(car == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddCarRepository);
            }
        }

        public bool Remove(ICar car)
        {
            if (cars.Remove(car))
            {
                return true;
            }
            return false;
        }


        public ICar FindBy(string property)
        {
            
            if (cars.FirstOrDefault(c => c.VIN == property) != null)
            {
                return cars.First(c => c.VIN == property);
            }
            return null;
        }


    }
}
