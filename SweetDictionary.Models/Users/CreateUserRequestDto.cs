using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Models.Users
{
    public sealed record CreateUserRequestDto(string Username, string FirstName, string LastName, string Email, string Password);
    
}
