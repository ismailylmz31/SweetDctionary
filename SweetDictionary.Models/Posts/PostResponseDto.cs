using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Models.Posts;

public sealed record PostResponseDto(Guid id, string Title, string Content);
