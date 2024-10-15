using AutoMapper;
using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Abstract;

namespace SweetDictionary.Service.Concretes;

public sealed class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository, IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto)
    {
        Post createdPost = _mapper.Map<Post>(dto);
        createdPost.Id = Guid.NewGuid();

        Post post = _postRepository.Add(createdPost);

        PostResponseDto response = _mapper.Map<PostResponseDto>(post);

        return new ReturnModel<PostResponseDto>
        {
            Data = response,
            Message = "Post eklendi.",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public ReturnModel<PostResponseDto> GetById(Guid id)
    {
        throw new NotImplementedException();
    }
}
