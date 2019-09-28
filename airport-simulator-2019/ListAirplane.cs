using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airport_simulator_2019
{

    class ListAirplane
    {
        static List<Airplane> ListOfAirplane;

        static void Create_List()
        {

            ListOfAirplane = new List<Airplane>();

            ListOfAirplane.Add(new Airplane
            {
                name = "ТУ-134",
                quantity_seat = 96,
                speed = 850,
                distance_fly = 2800,
                max_load = 8300,
                fuel = 8300,
                in_fly = false,
                location = "",
                rent_day = 400000,
                price_buy = 5000000,
                price_sale = 2500000,
                term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                name = "ТУ-204",
                quantity_seat = 214,
                speed = 850,
                max_load = 21000,
                distance_fly = 4500,
                fuel = 3500,
                in_fly = false,
                location = "",
                rent_day = 550000,
                price_buy = 6000000,
                price_sale = 3000000,
                term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                name = "SSJ-100",
                quantity_seat = 95,
                speed = 950,
                distance_fly = 3000,
                max_load = 12200,
                fuel = 2300,
                in_fly = false,
                location = "",
                rent_day = 620000,
                price_buy = 8000000,
                price_sale = 4000000,
                term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                name = "ИЛ-62",
                quantity_seat = 144,
                speed = 850,
                distance_fly = 6700,
                max_load = 25000,
                fuel = 7300,
                in_fly = false,
                location = "",
                rent_day = 800000,
                price_buy = 8000000,
                price_sale = 4000000,
                term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                name = "ИЛ-86",
                quantity_seat = 330,
                speed = 950,
                distance_fly = 4350,
                max_load = 42000,
                fuel = 9900,
                in_fly = false,
                location = "",
                rent_day = 9500000,
                price_buy = 10000000,
                price_sale = 5000000,
                term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                name = "Boeing 737-800",
                quantity_seat = 189,
                speed = 850,
                distance_fly = 5400,
                max_load = 20500,
                fuel = 2500,
                in_fly = false,
                location = "",
                rent_day = 710000,
                price_buy = 3000000,
                price_sale = 1500000,
                term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                name = "Airbus A310",
                quantity_seat = 218,
                speed = 900,
                distance_fly = 4000,
                max_load = 33500,
                fuel = 8300,
                in_fly = false,
                location = "",
                rent_day = 660000,
                price_buy = 5500000,
                price_sale = 2750000,
                term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                name = "Boeing 747-400",
                quantity_seat = 524,
                speed = 920,
                distance_fly = 13000,
                max_load = 70000,
                fuel = 11300,
                in_fly = false,
                location = "",
                rent_day = 1500000,
                price_buy = 35000000,
                price_sale = 175000000,
                term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                name = "Boeing 767-300",
                quantity_seat = 269,
                speed = 910,
                distance_fly = 9700,
                max_load = 40200,
                fuel = 4500,
                in_fly = false,
                location = "",
                rent_day = 1100000,
                price_buy = 27000000,
                price_sale = 13500000,
                term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                name = "Airbus A330-300",
                quantity_seat = 335,
                speed = 870,
                distance_fly = 10400,
                max_load = 51700,
                fuel = 5900,
                in_fly = false,
                location = "",
                rent_day = 12000000,
                price_buy = 22000000,
                price_sale = 11000000,
                term_date = -1
            });



        }
        
        static List<Airplane> GetList()
        {
            Create_List();
            return ListOfAirplane;       
            
        }
    };

}
