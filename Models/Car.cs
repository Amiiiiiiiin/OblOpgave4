using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OblOpgave4.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public int Price { get; set; }
        public string? LicensePlate { get; set; }
    }
}
