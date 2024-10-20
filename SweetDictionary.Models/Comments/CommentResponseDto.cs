using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Models.Comments
{
    public sealed record CommentResponseDto
    {
        public Guid id { get; init; }
        public string Text { get; init; }
        public string PostTitle { get; init; }

        public string AuthorFirstName { get; init; }

    }
}
