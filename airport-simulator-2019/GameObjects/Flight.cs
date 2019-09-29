using airport_simulator_2019.Engine;
using System;

namespace airport_simulator_2019.GameObjects
{
    public class Flight : GameObject
    {
        public FlightDirection Direction { get; set; }
        public int PriceFlight { get; set; } // оплата за рейс
        public DateTime ExpireDate { get; set; } // 

        public Flight()
        {
        }

    }
}
