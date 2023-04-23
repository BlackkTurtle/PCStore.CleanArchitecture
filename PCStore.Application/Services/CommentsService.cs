using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCStore.Application.Services.Contracts;
using PCStore.Domain.PCStoreEntities;
using PCStore.Domain.Repositories;

namespace PCStore.Application.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository commentsRepository;
        public CommentsService(ICommentsRepository repository)
        {
            this.commentsRepository = repository;
        }
        public Task AddAsync(Comment entity)
        {
            commentsRepository.AddAsync(entity);
            return Task.CompletedTask;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await commentsRepository.GetByIdAsync(id);
            if (entity != null)
            {
                await commentsRepository.DeleteAsync(entity);
                await commentsRepository.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Comment>> GetAllCommentsByArticleAsync(int article)
        {
            return commentsRepository.GetAllCommentsByArticleAsync(article);
        }

        public Task<Comment> GetByIdAsync(int id)
        {
            return commentsRepository.GetByIdAsync(id);
        }

        public Task SaveChangesAsync()
        {
            commentsRepository.SaveChangesAsync();
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Comment entity)
        {
            commentsRepository.UpdateAsync(entity);
            return Task.CompletedTask;
        }
    }
}
