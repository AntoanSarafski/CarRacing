using CarRacing.Models.Cars.Contracts;
using CarRacing.Models.Racers.Contracts;
using CarRacing.Repositories.Contracts;
using CarRacing.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarRacing.Repositories
{
    public class RacerRepository : IRepository<IRacer>
    {
        private readonly List<IRacer> racers;

        public RacerRepository()
        {
            racers = new List<IRacer>();
        }

        public IReadOnlyCollection<IRacer> Models => racers.AsReadOnly();

        public void Add(IRacer racer)
        {
            if (racer == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidAddRacerRepository);
            }
        }

        public bool Remove(IRacer racer)
        {
            if (racers.Remove(racer))
            {
                return true;
            }
            return false;
        }


        public IRacer FindBy(string property)
        {

            if (racers.FirstOrDefault(r => r.Username == property) != null)
            {
                return racers.First(r => r.Username == property);
            }
            return null;
        }


    }
}
