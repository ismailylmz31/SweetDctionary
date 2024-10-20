using AutoMapper;
using Core.Entities;
using SweetDictionary.Models.Categories;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Repository.Repositories.Concretes;
using SweetDictionary.Service.Abstract;
using SweetDictionary.Service.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SweetDictionary.Service.Concretes
{
    public sealed class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        private readonly CategoryBusinessRules _businessRules;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules businessRules)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequestDto dto)
        {
            Category createdCategory = _mapper.Map<Category>(dto);
            Category category = _categoryRepository.Add(createdCategory);
            CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);
            return new ReturnModel<CategoryResponseDto> {Data = response,
                Message = "Kategori eklendi.",
                Status = 200,
                Success = true

            };

        }

        public ReturnModel<CategoryResponseDto> Delete(int id)
        {
            
            _businessRules.IsPresent(id);
            Category? category = _categoryRepository.GetById(id);
            Category deletedCategory = _categoryRepository.Delete(category);

            return new ReturnModel<CategoryResponseDto> { 
                Message="Kategori silindi!",
                Status = 204,
                Success = true
            };

        }

        public ReturnModel<List<CategoryResponseDto>> GetAll()
        {
            
            var categories = _categoryRepository.GetAll();
            List<CategoryResponseDto> responses = _mapper.Map<List<CategoryResponseDto>>(categories);
            return new ReturnModel<List<CategoryResponseDto>> { 
                Data = responses,
                Status = 200,
                Success = true
            };
        }

        public ReturnModel<CategoryResponseDto> GetById(int id)
        {
          
            try
            {
                _businessRules.IsPresent(id);
                var category = _categoryRepository.GetById(id);
                var response = _mapper.Map<CategoryResponseDto>(category);
                return new ReturnModel<CategoryResponseDto>
                {
                    Data = response,
                    Message = "Aranan kategori bulundu",
                    Status = 200,
                    Success = true
                };
            }
            catch (Exception ex)
            { 
                return ExceptionHandler<CategoryResponseDto>.HandleException(ex); 
            }
        }

        public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequestDto dto)
        {

            try 
            {
                _businessRules.IsPresent(dto.Id);
                Category category = _mapper.Map<Category>(dto.Id);
                Category updated = _categoryRepository.Update(category);
                CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(updated);
                return new ReturnModel<CategoryResponseDto>
                {
                    Data = response,
                    Message = "kategori güncellendi",
                    Status = 200,
                    Success = true
                };
            }
            catch(Exception ex) { return ExceptionHandler<CategoryResponseDto>.HandleException(ex); }

       
        }
    }
}
