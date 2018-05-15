using System;
using System.Collections.Generic;
using System.Text;

namespace Viewer.Models
{
    public class ParkRide
    {
        public int Id { get; set; }
        public string Place { get; set; }
        public string Location { get; set; }
        public double Latitude { get; set; }
        public double Longtitude { get; set; }
        public int Capacity { get; set; }

    }
}
