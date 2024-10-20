using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Categories;
using SweetDictionary.Models.Posts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Abstract;
using SweetDictionary.Service.Concretes;

namespace SweetDictionary.WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService _categoryService): ControllerBase
{
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreateCategoryRequestDto dto)
    {
        var result = _categoryService.Add(dto);
        return Ok(result);
    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var result = _categoryService.GetById(id);
        return Ok(result);
    }

    [HttpGet("getbyname/{name}")]
    public IActionResult GetByName([FromRoute] string name)
    {
        var result = _categoryService.GetByName(name);
        return Ok(result);
    }

}
