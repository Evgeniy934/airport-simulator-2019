﻿using airport_simulator_2019.Engine;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace airport_simulator_2019.GameObjects
{
    public class Schedule : GameObject
    {
        public TrulyObservableCollection<Flight> Flights { get; private set; }

        public Schedule()
        {
            Flights = new TrulyObservableCollection<Flight>();
        }

        public void Add(Flight flight, Airplane airplane, DateTime time)
        {
            flight.Airplane = airplane;
            flight.DepartureTime = time;
            flight.ArrivalTime = time.AddHours(flight.Distance / airplane.Speed);

            Flights.Add(flight);
        }

        public void Remove(Flight flight)
        {
            if (!flight.Airplane.InFly)
            {
                Flights.Remove(flight);
            }
        }

        public void CompleteFlight(Airplane airplane)
        {
            Flight flight = Flights.FirstOrDefault(x => x.Airplane == airplane);
            Flights.Remove(flight);
        }

        public override void OnMinute()
        {
            for (int i = Flights.Count - 1; i >= 0; i--)
            {
                Flight flight = Flights[i];
                if (!flight.InFly)
                {
                    if (flight.DepartureTime.EqualsUpToMinutes(Game.Time))
                    {
                        bool canFly = flight.DepartureCity == flight.Airplane.Location
                            && flight.Airplane.CanFlyTo(flight.ArrivalCity);

                        if (canFly)
                        {
                            Game.Player.Spent(flight.FlightExpenses.Value);
                            flight.Airplane.FlyTo(flight.ArrivalCity);
                        }
                        else
                        {
                            Flights.Remove(flight);
                        }
                    }
                }
            }
        }
    }
}
