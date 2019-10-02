﻿using airport_simulator_2019.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

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
        public City Location { get; set; }  //местоположение
        public City FlyingTo { get; private set; }
        public DateTime ArrivalTime { get; private set; }
        public bool InFly => FlyingTo != null;
                                        
        ///

        public int PriceBuy { get; set; } // цена покупки
        public int PriceSale { get; set; } // цена продажи

        public DateTime? RentEnd { get; set; }
        public bool InRent => RentEnd != null;
        public bool ReturnTomorrow =>
            InRent ? (Game.Time.DayOfYear + 1) == RentEnd.Value.DayOfYear
            : false;

        public int RentDays
        {
            get
            {
                return InRent ? (RentEnd - Game.Time).GetValueOrDefault().Days + 1 : -1;
            }
        } // срок владения (аренды) в днях

        public Airplane()
        {
        }


        public void FlyTo(City city)
        {
            FlyingTo = city;
            ArrivalTime = Game.Time + GetFlyDuration(Location, city);
            RaisePropertyChanged();
        }

        public bool IsAvailableForFlight(Flight flight)
        {
            return (DistanceFly >= flight.Distance) && (MaxLoad >= flight.RequiredLoad);
        }

        public TimeSpan GetFlyDuration(City a, City b)
        {
            int distance = CityCatalog.GetDistance(a, b);
            return TimeSpan.FromHours(distance / Speed);
        }

        public override void OnMinute()
        {
            if (InFly)
            {
                if (Game.Time >= ArrivalTime)
                {
                    // flight end
                    Location = FlyingTo;
                    FlyingTo = null;
                    Game.Player.CompleteFlight(this);
                    RaisePropertyChanged();
                }
            }
        }

        public override void OnDayBegin()
        {
        }
    }

}
