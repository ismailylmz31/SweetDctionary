using Core.Exceptions;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Repository.Repositories.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetDictionary.Service.Rules
{
    public class CommentBusinessRules(ICommentRepository _commentRepository)
    {

        public void IsPresent(Guid id)
        {
            var post = _commentRepository.GetById(id);
            if (post is null)
            {
                throw new NotFoundException($"İlgili id ye göre yorum bulunamadı : {id}");
            }



        }

    }
}
