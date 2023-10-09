﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental.Shared.DTO_s
{
    public class UserDTO
    {
        public Guid UserId { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public double PhoneNo { get; set; }

    }
}
