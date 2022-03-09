using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OblOpgave4.Models;

namespace OblOpgave4.Managers
{
    public class CarManager
    {
        private static int nextID = 1;
        private static List<Car> data = new List<Car>()
        {
            new Car() {Id = nextID++, Model = "Audi TT", Price = 100000, LicensePlate = "ABC123"},
            new Car() {Id = nextID++, Model = "Audi B4", Price = 200000, LicensePlate = "DEF456" },
            new Car() {Id = nextID++, Model = "Audi B3", Price = 300000, LicensePlate = "GHI789"},
            new Car() {Id = nextID++, Model = "Audi B6", Price = 400000, LicensePlate = "JKL123"},
            new Car() {Id = nextID++, Model = "Audi C52", Price = 2523525, LicensePlate = "6436V5"},
            new Car() {Id = nextID++, Model = "Audi C35", Price = 2000, LicensePlate = "IOTY12"}
        };

        public List<Car> GetAll(int? maxPrice)
        {
            List<Car> result = new List<Car>(data);
            if (maxPrice != null)
            {
                result = result.FindAll(filterCar => filterCar.Price <= maxPrice);
            }
            return result;
        }

        public Car GetById(int id)
        {
            return data.Find(car => car.Id == id);
        }

        public Car AddCar(Car newCar)
        {
            newCar.Id = nextID++;
            data.Add(newCar);
            return newCar;
        }

        public Car Delete(int id)
        {
            Car car = data.Find(car => car.Id == id);
            if (car == null) return null;
            data.Remove(car);
            return car;
        }
    }
}
