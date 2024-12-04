﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductManagement.Domain.Users
{
    public class User
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string PasswordHash { get; set; } = null!;
    }
}