using airport_simulator_2019.Engine;
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
        public Flight Flight { get; private set; }
        public bool InFly => Flight != null;

        ///

        public int PriceBuy { get; set; } // цена покупки
        public int PriceSale { get; set; } // цена продажи

        public DateTime? RentEnd { get; set; }
        public bool InRent => RentEnd != null;
        public bool ReturnTomorrow =>
            InRent ? Game.Time.Date == RentEnd
            : false;

        public int RentDays
        {
            get
            {
                return InRent ? (RentEnd - Game.Time.Date).GetValueOrDefault().Days + 1 : -1;
            }
        } // срок владения (аренды) в днях

        public Airplane()
        {
        }

        public bool CanFlyTo(Flight flight) => flight.DepartureCity == Location
            && CanFlyTo(flight.ArrivalCity);

        public bool CanFlyTo(City city) => city != Location
            && CityCatalog.GetDistance(Location, city) <= DistanceFly;

        public void FlyTo(Flight flight)
        {
            if (CanFlyTo(flight))
            {
                Flight = flight;
                Flight.ArrivalTime = Game.Time + GetFlyDuration(Flight.DepartureCity, Flight.ArrivalCity);
                RaisePropertyChanged();
            }
        }

        public bool IsAvailableForFlight(Flight flight)
        {
            return (DistanceFly >= flight.Distance) && 
                (flight.IsPassengerFlight ? (QuantitySeat >= flight.RequiredLoad) : (MaxLoad >= flight.RequiredLoad));
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
                if (Game.Time >= Flight.ArrivalTime)
                {
                    Location = Flight.ArrivalCity;
                    Game.Player.CompleteFlight(Flight);
                    Flight = null;
                    RaisePropertyChanged();
                }
            }
        }

        public override void OnDayBegin()
        {
            if (InRent)
            {
                RaisePropertyChanged();
            }
        }
    }

}
