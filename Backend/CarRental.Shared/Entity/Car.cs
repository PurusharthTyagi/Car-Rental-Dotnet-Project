﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Shared.Entity
{
    public class Car
    {
        public Guid CarId { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public double RentalPricePerDay { get; set; }
        public bool IsAvailable { get; set; } = true;
        public string RegistrationNo { get; set; }
    }
}
