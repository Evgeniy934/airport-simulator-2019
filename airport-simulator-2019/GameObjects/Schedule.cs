using airport_simulator_2019.Engine;
using System;

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
            flight.ArrivalTime = time + airplane.GetFlyDuration(flight.ArrivalCity);
            Flights.Add(flight);
        }

        public void Remove(Flight flight)
        {
            if (!flight.Airplane.InFly)
            {
                Flights.Remove(flight);
            }
        }

        public override void OnMinute()
        {
            for (int i = Flights.Count - 1; i >= 0; i--)
            {
                Flight flight = Flights[i];
                if (!flight.InFly)
                {
                    if (flight.Airplane.Location == flight.DepartureCity)
                    {
                        if (flight.DepartureTime.EqualsUpToMinutes(Game.Time))
                        {
                            Game.Player.Spent(flight.FlightExpenses.Value);
                            flight.Begin();
                        }
                    }
                    else
                    {
                        if (flight.DepartureTime.EqualsUpToMinutes(Game.Time))
                        {
                            Flights.Remove(flight);
                        }
                    }
                }
                else
                {
                    if (flight.ArrivalTime.EqualsUpToMinutes(Game.Time))
                    {
                        Game.Player.Pay(flight.PriceFlight);
                        flight.Complete();
                        Flights.Remove(flight);
                    }
                }
            }
        }
    }
}
