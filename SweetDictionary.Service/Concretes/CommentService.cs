using AutoMapper;
using Core.Entities;
using SweetDictionary.Models.Comments;
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

namespace SweetDictionary.Service.Concretes
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly CommentBusinessRules _businessRules;

        public CommentService(ICommentRepository commentRepository, IMapper mapper, CommentBusinessRules businessRules)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public ReturnModel<CommentResponseDto> Add(CreateCommentRequestDto dto)
        {
            Comment createdComment = _mapper.Map<Comment>(dto);
            createdComment.Id = Guid.NewGuid();
            Comment comment = _commentRepository.Add(createdComment);
            CommentResponseDto response = _mapper.Map<CommentResponseDto>(comment);
            return new ReturnModel<CommentResponseDto>
            {
                Data = response,
                Message = "Yorum Eklendi.",
                Status  =200,
                Success = true

            };
        }

        public ReturnModel<CommentResponseDto> Delete(Guid id)
        {
            _businessRules.IsPresent(id);
            Comment? comment = _commentRepository.GetById(id);
            Comment deletedComment = _commentRepository.Delete(comment);
            return new ReturnModel<CommentResponseDto> { 
                Message = "Yorum silindi",
                Status=204,
                Success = true

            };
        }

        public ReturnModel<List<CommentResponseDto>> GetAll()
        {            
            var comments = _commentRepository.GetAll();
            List<CommentResponseDto> responses = _mapper.Map<List<CommentResponseDto>>(comments);
            return new ReturnModel<List<CommentResponseDto>> { 
                Data = responses,
                Message = string.Empty,
                Status = 200,
                Success = true };
        }

        public ReturnModel<CommentResponseDto> GetById(Guid id)
        {          

            try
            {
                _businessRules.IsPresent(id);
                var comment = _commentRepository.GetById(id);
                var response = _mapper.Map<CommentResponseDto>(comment);
                return new ReturnModel<CommentResponseDto>
                {
                    Data = response,
                    Message = string.Empty,
                    Status = 200,
                    Success = true
                };
            }catch(Exception ex) 
            {
                return ExceptionHandler<CommentResponseDto>.HandleException(ex);
            }
        }

        public ReturnModel<CommentResponseDto> Update(UpdateCommentRequestDto dto)
        {          
            try
            {
                _businessRules.IsPresent(dto.Id);
                Comment comment = _mapper.Map<Comment>(dto);
                Comment updated = _commentRepository.Update(comment);
                CommentResponseDto response = _mapper.Map<CommentResponseDto>(updated);
                return new ReturnModel<CommentResponseDto>
                {
                    Data = response,
                    Message = string.Empty,
                    Status = 200,
                    Success = true
                };
            }
            catch (Exception ex) { return ExceptionHandler<CommentResponseDto>.HandleException(ex); return ExceptionHandler<CommentResponseDto>.HandleException(ex); }
        }
    }
}
