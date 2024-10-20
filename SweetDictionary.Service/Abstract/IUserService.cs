using Core.Entities;
using SweetDictionary.Models.Categories;
using SweetDictionary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Abstract
{
    public interface IUserService
    {
        ReturnModel<UserResponseDto> Add(CreateUserRequestDto dto);
        ReturnModel<List<UserResponseDto>> GetAll();

        ReturnModel<UserResponseDto> GetById(long id);

        ReturnModel<UserResponseDto> Update(UpdateUserRquestDto dto);

        ReturnModel<UserResponseDto> Delete(long id);
    }
}
