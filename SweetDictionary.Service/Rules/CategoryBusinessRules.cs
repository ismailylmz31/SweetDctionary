using Core.Exceptions;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Repositories.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Rules
{
    public class CategoryBusinessRules(ICategoryRepository _categoryRepository)
    {
        public void IsPresent(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category is null)
            {
                throw new NotFoundException($"İlgili id ye göre Kategori bulunamadı : {id}");
            }
        }
    }
}
