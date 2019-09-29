﻿using System;
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

            direction.Distance = (int) departureCoordinate.GetDistanceTo(arrivalCoordinate);

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

        }
    }
}