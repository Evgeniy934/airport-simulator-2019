﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airport_simulator_2019
{
   public class Airplane1
    {
        public string Name { get; set; }  // название самолета
        public int DistanceFly { get; set; } // макс расстояние полета
        public int MaxLoad { get; set; } // макс вес
        public int Speed { get; set; } // скорость
        public int QuantitySeat { get; set; } // кол-во мест
        public int Fuel { get; set; } // расход топлива
        public int PriceBuy { get; set; } // цена покупки
        public int PriceSale { get; set; }  // цена продажи
        public int RentDay { get; set; } // цена аренды за 1 день
        public int TermDate { get; set; } // срок владения (аренды) в днях
        public string Location { get; set; }  //местоположение
        public Boolean InFly { get; set; } // находится ли самолет в полете




    }
}
