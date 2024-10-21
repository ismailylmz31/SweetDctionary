using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Categories;
using SweetDictionary.Models.Comments;
using SweetDictionary.Service.Abstract;
using SweetDictionary.Service.Concretes;

namespace SweetDictionary.WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class CommentController(ICommentService _commentService):ControllerBase
{
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _commentService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody] CreateCommentRequestDto dto)
    {
        var result = _commentService.Add(dto);
        return Ok(result);
    }

    [HttpGet("getbyid/{id}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _commentService.GetById(id);
        return Ok(result);
    }
    // Yeni eklenen: Update işlemi için
    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateCommentRequestDto dto)
    {
        var result = _commentService.Update(dto);
        return Ok(result);
    }

    // Yeni eklenen: Delete işlemi için
    [HttpDelete("delete/{id}")]
    public IActionResult Delete([FromRoute] Guid id)
    {
        var result = _commentService.Delete(id);
        return Ok(result);
    }
}
