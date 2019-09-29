using airport_simulator_2019.Engine;
using System;

namespace airport_simulator_2019.GameObjects
{
    public class Airplane : GameObject
    {
        public string Name { get; set; }  // название самолета
        public int DistanceFly { get; set; } // макс расстояние полета
        public int MaxLoad { get; set; } // макс вес
        public int Speed { get; set; } // скорость
        public int QuantitySeat { get; set; } // кол-во мест
        public int Fuel { get; set; } // расход топлива
        public int PriceRent { get; set; } // цена аренды за 1 день
        public int RentDays { get; set; } // срок владения (аренды) в днях
        public City Location { get; set; }  //местоположение
        public bool InFly { get; set; } // находится ли самолет в полете
                                        
        ///

        public int PriceBuy { get; set; } // цена покупки
        public int PriceSale { get; set; } // цена продажи

        public DateTime? RentEnd { get; set; }

        public Airplane()
        {
        }
    }

}
