using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Posts;
using SweetDictionary.Models.Users;
using SweetDictionary.Service.Abstract;
using SweetDictionary.Service.Concretes;

namespace SweetDictionary.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService _userService):ControllerBase
    {
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            return Ok(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CreateUserRequestDto dto)
        {
            var result = _userService.Add(dto);
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById([FromRoute] long id)
        {
            var result = _userService.GetById(id);
            return Ok(result);
        }
        // Yeni eklenen: Update işlemi için
        [HttpPut("update")]
        public IActionResult Update([FromBody] UpdateUserRquestDto dto)
        {
            var result = _userService.Update(dto);
            return Ok(result);
        }

        // Yeni eklenen: Delete işlemi için
        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] long id)
        {
            var result = _userService.Delete(id);
            return Ok(result);
        }
    }
}
