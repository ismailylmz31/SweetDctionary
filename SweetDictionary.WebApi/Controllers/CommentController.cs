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
}
