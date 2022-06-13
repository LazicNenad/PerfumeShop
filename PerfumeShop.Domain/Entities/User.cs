﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerfumeShop.Domain.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<UserUseCase> UseCases { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();


    }
}
