using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Models.Users
{
    public sealed record UpdateUserRquestDto(long Id,string Email, string Password);

}
