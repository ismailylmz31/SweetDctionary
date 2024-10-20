using Core.Entities;
using SweetDictionary.Models.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Abstract
{
    public interface ICategoryService
    {
        ReturnModel<CategoryResponseDto> Add(CreateCategoryRequestDto dto);
        ReturnModel<List<CategoryResponseDto>> GetAll();

        ReturnModel<CategoryResponseDto> GetById(int id);

        ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequestDto dto);

        ReturnModel<CategoryResponseDto> Delete(int id);

    }
}
