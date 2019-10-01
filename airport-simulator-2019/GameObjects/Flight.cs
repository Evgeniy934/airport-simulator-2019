using airport_simulator_2019.Engine;
using System;

namespace airport_simulator_2019.GameObjects
{
    public class Flight : GameObject
    {
        public City DepartureCity { get; set; }
        public City ArrivalCity { get; set; }
        public int Distance => CityCatalog.GetDistance(DepartureCity, ArrivalCity);
        public int PriceFlight { get; set; } // оплата за рейс
        public DateTime ExpireDate { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public Airplane Airplane { get; set; }
        public bool InFly => Airplane?.InFly == true;
        
        public Flight()
        {
        }

    }
}
