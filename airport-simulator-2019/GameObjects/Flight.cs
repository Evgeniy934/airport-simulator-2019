using airport_simulator_2019.Engine;
using System;

namespace airport_simulator_2019.GameObjects
{
    public class Flight : GameObject
    {
        public string DepartureCity { get; set; }  //город отправления
        public string DestinationCity { get; set; }  //город назначения
        public int Distance { get; set; } //расстояние [в км - определяется по городам]
        public int PriceFlight { get; set; } // оплата за рейс
        public DateTime ExpireDate { get; set; } // 

        public Flight()
        {
        }

    }
}
