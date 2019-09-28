using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airport_simulator_2019
{
   public class Airplane
    {
        public string name;  // название самолета
        public int distance_fly; // макс расстояние полета
        public int max_load; // макс вес
        public int speed;  // скорость
        public int quantity_seat; // кол-во мест
        public int fuel; // расход топлива
        public int price_buy; // цена покупки
        public int price_sale;  // цена продажи
        public int rent_day; // цена аренды за 1 день
        public int term_date; // срок владения (аренды) в днях
        public string location;  //местоположение
        public Boolean in_fly; // находится ли самолет в полете


       

    }
}
