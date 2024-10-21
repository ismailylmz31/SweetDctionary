using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Comments;
using SweetDictionary.Models.Posts;
using SweetDictionary.Service.Abstract;
using SweetDictionary.Service.Concretes;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController(IPostService _postService) : ControllerBase
{
    


    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _postService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody]CreatePostRequestDto dto)
    {
        var result = _postService.Add(dto);
        return Ok(result);
    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById([FromRoute]Guid id)
    {
        var result = _postService.GetById(id);
        return Ok(result);
    }
    // Yeni eklenen: Update işlemi için
    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdatePostRequestDto dto)
    {
        var result = _postService.Update(dto);
        return Ok(result);
    }

    // Yeni eklenen: Delete işlemi için
    [HttpDelete("delete/{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var result = _postService.Delete(id);
        return Ok(result);
    }
}
