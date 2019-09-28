using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airport_simulator_2019
{

    public class ListAirplane
    {
        public static List<Airplane> ListOfAirplane;

        public static void Create_List()
        {

            ListOfAirplane = new List<Airplane>();

            ListOfAirplane.Add(new Airplane
            {
                Name = "ТУ-134",
                Quantity_seat = 96,
                Speed = 850,
                Distance_fly = 2800,
                Max_load = 8300,
                Fuel = 8300,
                In_fly = false,
                Location = "",
                Rent_day = 400000,
                Price_buy = 5000000,
                Price_sale = 2500000,
                Term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                Name = "ТУ-204",
                Quantity_seat = 214,
                Speed = 850,
                Max_load = 21000,
                Distance_fly = 4500,
                Fuel = 3500,
                In_fly = false,
                Location = "",
                Rent_day = 550000,
                Price_buy = 6000000,
                Price_sale = 3000000,
                Term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                Name = "SSJ-100",
                Quantity_seat = 95,
                Speed = 950,
                Distance_fly = 3000,
                Max_load = 12200,
                Fuel = 2300,
                In_fly = false,
                Location = "",
                Rent_day = 620000,
                Price_buy = 8000000,
                Price_sale = 4000000,
                Term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                Name = "ИЛ-62",
                Quantity_seat = 144,
                Speed = 850,
                Distance_fly = 6700,
                Max_load = 25000,
                Fuel = 7300,
                In_fly = false,
                Location = "",
                Rent_day = 800000,
                Price_buy = 8000000,
                Price_sale = 4000000,
                Term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                Name = "ИЛ-86",
                Quantity_seat = 330,
                Speed = 950,
                Distance_fly = 4350,
                Max_load = 42000,
                Fuel = 9900,
                In_fly = false,
                Location = "",
                Rent_day = 9500000,
                Price_buy = 10000000,
                Price_sale = 5000000,
                Term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                Name = "Boeing 737-800",
                Quantity_seat = 189,
                Speed = 850,
                Distance_fly = 5400,
                Max_load = 20500,
                Fuel = 2500,
                In_fly = false,
                Location = "",
                Rent_day = 710000,
                Price_buy = 3000000,
                Price_sale = 1500000,
                Term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                Name = "Airbus A310",
                Quantity_seat = 218,
                Speed = 900,
                Distance_fly = 4000,
                Max_load = 33500,
                Fuel = 8300,
                In_fly = false,
                Location = "",
                Rent_day = 660000,
                Price_buy = 5500000,
                Price_sale = 2750000,
                Term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                Name = "Boeing 747-400",
                Quantity_seat = 524,
                Speed = 920,
                Distance_fly = 13000,
                Max_load = 70000,
                Fuel = 11300,
                In_fly = false,
                Location = "",
                Rent_day = 1500000,
                Price_buy = 35000000,
                Price_sale = 175000000,
                Term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                Name = "Boeing 767-300",
                Quantity_seat = 269,
                Speed = 910,
                Distance_fly = 9700,
                Max_load = 40200,
                Fuel = 4500,
                In_fly = false,
                Location = "",
                Rent_day = 1100000,
                Price_buy = 27000000,
                Price_sale = 13500000,
                Term_date = -1
            });

            ListOfAirplane.Add(new Airplane
            {
                Name = "Airbus A330-300",
                Quantity_seat = 335,
                Speed = 870,
                Distance_fly = 10400,
                Max_load = 51700,
                Fuel = 5900,
                In_fly = false,
                Location = "",
                Rent_day = 12000000,
                Price_buy = 22000000,
                Price_sale = 11000000,
                Term_date = -1
            });



        }
        
        public static List<Airplane> GetList()
        {
            Create_List();
            return ListOfAirplane;       
            
        }
    };

}
