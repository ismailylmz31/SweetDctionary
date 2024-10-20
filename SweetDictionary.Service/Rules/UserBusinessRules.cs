using Core.Exceptions;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Repository.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Rules
{
    public class UserBusinessRules(IUserRepository _userRepository)
    {
        public void IsPresent(long id)
        {
            var post = _userRepository.GetById(id);
            if (post is null)
            {
                throw new NotFoundException($"İlgili id ye göre kullanıcı bulunamadı : {id}");
            }



        }
    }
}
