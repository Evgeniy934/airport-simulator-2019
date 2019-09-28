using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airport_simulator_2019
{
   public class Airplane
    {
        public string Name { get; set; }  // название самолета
        public int Distance_fly { get; set; } // макс расстояние полета
        public int Max_load { get; set; } // макс вес
        public int Speed { get; set; } // скорость
        public int Quantity_seat { get; set; } // кол-во мест
        public int Fuel { get; set; } // расход топлива
        public int Price_buy { get; set; } // цена покупки
        public int Price_sale { get; set; }  // цена продажи
        public int Rent_day { get; set; } // цена аренды за 1 день
        public int Term_date { get; set; } // срок владения (аренды) в днях
        public string Location { get; set; }  //местоположение
        public Boolean In_fly { get; set; } // находится ли самолет в полете




    }
}
