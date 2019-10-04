﻿using airport_simulator_2019.Engine;
using System;
using System.Linq;

namespace airport_simulator_2019.GameObjects
{
    public class Flight : GameObject
    {
        public City DepartureCity { get; set; }
        public City ArrivalCity { get; set; }
        public int Distance => CityCatalog.GetDistance(DepartureCity, ArrivalCity);
        public string Type { get; set; }
        public string Regularity => "Разовый";
        public string Frequency => "";
        public int RequiredLoad { get; set; }
        public int PricePassenger { get; set;}
        public int PriceFlight { get; set; } // оплата за рейс
        public DateTime ExpireDate { get; set; }
        public int Forfeit { get; set; }

        public DateTime DepartureTime { get; set; }        
        public DateTime ArrivalTime { get; set; }
        public Airplane Airplane { get; set; }
        public TimeSpan? TimeInFly => ArrivalTime - DepartureTime;
        public int? FlightExpenses => Airplane == null ? default(int?)
            : (int) (TimeInFly.Value.TotalHours * Airplane.Fuel * GasStation.FuelPrice );
        public bool InFly => Airplane?.InFly == true;
        public bool PlayerHasSuitableAirplane 
            => Game.Player.Airplanes.FirstOrDefault(x => x.IsAvailableForFlight(this)) != null;
        public bool IsRegular => Regularity != "Разовый";
        public bool IsPassengerFlight => Type == "Пассажирский";

        public void Complete()
        {
            if (InFly)
            {
                Airplane.Arrive();
                Airplane = null;
                RaisePropertyChanged();
            }
        }

        public void Begin()
        {
            if (!InFly)
            {
                Airplane.FlyTo(ArrivalCity);
                RaisePropertyChanged();
            }
        }
        
        public Flight()
        {
        }

    }
}
