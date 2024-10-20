using Core.Entities;
using SweetDictionary.Models.Categories;
using SweetDictionary.Models.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Abstract
{
    public interface ICommentService
    {
        ReturnModel<CommentResponseDto> Add(CreateCommentRequestDto dto);
        ReturnModel<List<CommentResponseDto>> GetAll();

        ReturnModel<CommentResponseDto> GetById(Guid id);

        ReturnModel<CommentResponseDto> Update(UpdateCommentRequestDto dto);

        ReturnModel<CommentResponseDto> Delete(Guid id);
    }
}
