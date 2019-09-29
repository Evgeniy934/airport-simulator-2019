using airport_simulator_2019.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airport_simulator_2019
{

    public class ListAirplane
    {
        public static List<Airplane1> ListOfAirplane;

        public static void Create_List()
        {

            ListOfAirplane = new List<Airplane1>();

        //    ListOfAirplane.Add(new Airplane
        //    {
        //        Name = "ТУ-134",
        //        QuantitySeat = 96,
        //        Speed = 850,
        //        DistanceFly = 2800,
        //        MaxLoad = 8300,
        //        Fuel = 8300,
        //        InFly = false,
        //        Location = "",
        //        RentDay = 400000,
        //        PriceBuy = 5000000,
        //        PriceSale = 2500000,
        //        TermDate = -1
        //    });

        //    ListOfAirplane.Add(new Airplane
        //    {
        //        Name = "ТУ-204",
        //        QuantitySeat = 214,
        //        Speed = 850,
        //        MaxLoad = 21000,
        //        DistanceFly = 4500,
        //        Fuel = 3500,
        //        InFly = false,
        //        Location = "",
        //        RentDay = 550000,
        //        PriceBuy = 6000000,
        //        PriceSale = 3000000,
        //        TermDate = -1
        //    });

        //    ListOfAirplane.Add(new Airplane
        //    {
        //        Name = "SSJ-100",
        //        QuantitySeat = 95,
        //        Speed = 950,
        //        DistanceFly = 3000,
        //        MaxLoad = 12200,
        //        Fuel = 2300,
        //        InFly = false,
        //        Location = "",
        //        RentDay = 620000,
        //        PriceBuy = 8000000,
        //        PriceSale = 4000000,
        //        TermDate = -1
        //    });

        //    ListOfAirplane.Add(new Airplane
        //    {
        //        Name = "ИЛ-62",
        //        QuantitySeat = 144,
        //        Speed = 850,
        //        DistanceFly = 6700,
        //        MaxLoad = 25000,
        //        Fuel = 7300,
        //        InFly = false,
        //        Location = "",
        //        RentDay = 800000,
        //        PriceBuy = 8000000,
        //        PriceSale = 4000000,
        //        TermDate = -1
        //    });

        //    ListOfAirplane.Add(new Airplane
        //    {
        //        Name = "ИЛ-86",
        //        QuantitySeat = 330,
        //        Speed = 950,
        //        DistanceFly = 4350,
        //        MaxLoad = 42000,
        //        Fuel = 9900,
        //        InFly = false,
        //        Location = "",
        //        RentDay = 9500000,
        //        PriceBuy = 10000000,
        //        PriceSale = 5000000,
        //        TermDate = -1
        //    });

        //    ListOfAirplane.Add(new Airplane
        //    {
        //        Name = "Boeing 737-800",
        //        QuantitySeat = 189,
        //        Speed = 850,
        //        DistanceFly = 5400,
        //        MaxLoad = 20500,
        //        Fuel = 2500,
        //        InFly = false,
        //        Location = "",
        //        RentDay = 710000,
        //        PriceBuy = 3000000,
        //        PriceSale = 1500000,
        //        TermDate = -1
        //    });

        //    ListOfAirplane.Add(new Airplane
        //    {
        //        Name = "Airbus A310",
        //        QuantitySeat = 218,
        //        Speed = 900,
        //        DistanceFly = 4000,
        //        MaxLoad = 33500,
        //        Fuel = 8300,
        //        InFly = false,
        //        Location = "",
        //        RentDay = 660000,
        //        PriceBuy = 5500000,
        //        PriceSale = 2750000,
        //        TermDate = -1
        //    });

        //    ListOfAirplane.Add(new Airplane
        //    {
        //        Name = "Boeing 747-400",
        //        QuantitySeat = 524,
        //        Speed = 920,
        //        DistanceFly = 13000,
        //        MaxLoad = 70000,
        //        Fuel = 11300,
        //        InFly = false,
        //        Location = "",
        //        RentDay = 1500000,
        //        PriceBuy = 35000000,
        //        PriceSale = 175000000,
        //        TermDate = -1
        //    });

        //    ListOfAirplane.Add(new Airplane
        //    {
        //        Name = "Boeing 767-300",
        //        QuantitySeat = 269,
        //        Speed = 910,
        //        DistanceFly = 9700,
        //        MaxLoad = 40200,
        //        Fuel = 4500,
        //        InFly = false,
        //        Location = "",
        //        RentDay = 1100000,
        //        PriceBuy = 27000000,
        //        PriceSale = 13500000,
        //        TermDate = -1
        //    });

        //    ListOfAirplane.Add(new Airplane
        //    {
        //        Name = "Airbus A330-300",
        //        QuantitySeat = 335,
        //        Speed = 870,
        //        DistanceFly = 10400,
        //        MaxLoad = 51700,
        //        Fuel = 5900,
        //        InFly = false,
        //        Location = "",
        //        RentDay = 12000000,
        //        PriceBuy = 22000000,
        //        PriceSale = 11000000,
        //        TermDate = -1
        //    });



        }
        
        public static List<Airplane1> GetList()
        {
            Create_List();
            return ListOfAirplane;       
            
        }
    };

}
