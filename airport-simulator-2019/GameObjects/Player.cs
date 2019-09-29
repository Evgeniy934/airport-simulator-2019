﻿using airport_simulator_2019.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace airport_simulator_2019.GameObjects
{
    public class Player : GameObject
    {
        public List<Airplane> Airplanes { get; }
        public List<Flight> Flights { get; }
        public int Balance { get; private set; }

        public Player()
        {
            Airplanes = new List<Airplane>();
            Flights = new List<Flight>();
            Balance = 100000000;
        }

        public void Pay(int howMuch)
        { 
            if (Balance >= howMuch)
            {
                Balance -= howMuch;
            }
        }

        public void BuyAirplane(Airplane airplane)
        {
            int price = Game.Shop.Airplanes.Find(x => x == airplane).PriceBuy;
            if (Balance >= price)
            {
                Airplane plane = Game.Shop.Buy(airplane);
                Airplanes.Add(plane);
                Balance -= price;
            }
        }

        public void RentAirplane(Airplane airplane, DateTime dateEnd)
        {
            int price = Game.Shop.Airplanes.Find(x => x == airplane).PriceRent;
            if (Balance >= price)
            {
                Airplane plane = Game.Shop.Rent(airplane, dateEnd);
                Airplanes.Add(plane);
                Balance -= price;
            }
        }

        public void TakeFromFlightBoard(Flight flight)
        {
            Flight taken = Game.FlightBoard.TakeFlight(flight);
            Flights.Add(taken);
        }

    }

}
