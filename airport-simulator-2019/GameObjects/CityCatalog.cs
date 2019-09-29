using System;
using System.Collections.Generic;
using System.Device.Location;

namespace airport_simulator_2019.GameObjects
{
    public static class CityCatalog
    {
        static Random _random = new Random();

        public static List<City> Cities { get; private set; }

        public static FlightDirection GetFlightDirection()
        {
            var direction = new FlightDirection();

            direction.Departure = GetRandomCity();
            do
            {
                direction.Arrival = GetRandomCity();
            } while (direction.Departure == direction.Arrival);

            var departureCoordinate = new GeoCoordinate(direction.Departure.Latitude, direction.Departure.Longitude);
            var arrivalCoordinate = new GeoCoordinate(direction.Arrival.Latitude, direction.Arrival.Longitude);

            direction.Distance = (int) departureCoordinate.GetDistanceTo(arrivalCoordinate) / 1000;

            return direction;
        }

        public static City GetRandomCity()
        {
            return Cities[_random.Next(Cities.Count)];
        }

        static CityCatalog()
        {
            Cities = new List<City>();
            Cities.Add(new City
            {
                Name = "Пермь",
                Latitude = 58.029682,
                Longitude = 56.266792
            });
            Cities.Add(new City
            {
                Name = "Липецк",
                Latitude = 52.603241,
                Longitude = 39.572941
            });
            Cities.Add(new City
            {
                Name = "Лондон",
                Latitude = 51.507351,
                Longitude = -0.127758
            });
            Cities.Add(new City
            {
                Name = "Сан-Франциско",
                Latitude = 37.774929,
                Longitude = -122.419418
            });
            Cities.Add(new City
            {
                Name = "Сидней",
                Latitude = -33.868820,
                Longitude = 151.209290
            });

            Cities.Add(new City
            {
                Name = "Москва",
                Latitude = 55.75222,
                Longitude = 37.61556
            });

            Cities.Add(new City
            {
                Name = "Казань",
                Latitude = 55.78874,
                Longitude = 49.12214
            });

            Cities.Add(new City
            {
                Name = "Волгоград",
                Latitude = 48.707103,
                Longitude = 44.516939
            });

            Cities.Add(new City
            {
                Name = "Нью-Йорк",
                Latitude = 40.7142700,
                Longitude = -74.0059700
            });
            Cities.Add(new City
            {
                Name = "Ростов-На-Дону",
                Latitude = 47.222531,
                Longitude = 39.718705
            });
            Cities.Add(new City
            {
                Name = "Вашингтон",
                Latitude = 38.89511,
                Longitude = -77.03637
            });
            Cities.Add(new City
            {
                Name = "Милан",
                Latitude = 45.4642700,
                Longitude = 9.1895100
            });
            Cities.Add(new City
            {
                Name = "Токио",
                Latitude = 35.6895,
                Longitude = 139.69171
            });
            Cities.Add(new City
            {
                Name = "Гонконг",
                Latitude = 22.2855200,
                Longitude = 114.1576900
            });
            Cities.Add(new City
            {
                Name = "Сидней",
                Latitude = 48.472584,
                Longitude = 135.057732
            });

        }
    }
}
