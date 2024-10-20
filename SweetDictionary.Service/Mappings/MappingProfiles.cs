using AutoMapper;
using SweetDictionary.Models.Categories;
using SweetDictionary.Models.Comments;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreatePostRequestDto,Post>();
            CreateMap<Post, PostResponseDto>();
            CreateMap<CreateCategoryRequestDto, Category>();
            CreateMap<Category, CategoryResponseDto>();
            CreateMap<CreateCommentRequestDto, Comment>();
            CreateMap<Comment, CommentResponseDto>();
            CreateMap<CreateUserRequestDto,User>();
            CreateMap<User,UserResponseDto>();

        }
    }
}
