using System;
using System.Collections.Generic;

namespace ParkAndRide_REST.Models
{
    public partial class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string Place { get; set; }
        public string Price { get; set; }
        public string Category { get; set; }
        public string Information { get; set; }
    }
}
