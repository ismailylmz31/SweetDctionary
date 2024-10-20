﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Models.Users
{
    public sealed record UserResponseDto
    {

        public long id { get; init; }
        public string Username { get; init; }

        public string FirstName { get; init; }

        public string LastName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
    }
}
