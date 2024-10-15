namespace SweetDictionary.Models.Posts;

public sealed record UpdatePostRequestDto(Guid id,string Title, string Content);
