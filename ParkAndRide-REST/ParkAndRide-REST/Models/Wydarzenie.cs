using System;
using System.Collections.Generic;

namespace ParkAndRide_REST.Models
{
    public partial class Wydarzenie
    {
        public int Id { get; set; }
        public string Nazwa { get; set; }
        public string Data { get; set; }
        public string Miejscowosc { get; set; }
        public string Ulica { get; set; }
        public string NrBudynku { get; set; }
        public string NrMieszkania { get; set; }
        public string Cena { get; set; }
        public string Kategoria { get; set; }
        public string Informacje { get; set; }
    }
}
