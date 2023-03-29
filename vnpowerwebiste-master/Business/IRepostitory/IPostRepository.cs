using Business.IRepository;
using Entities.Entities;
using Entities.Helpers;
using Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.IRepostitory
{
    public interface IPostRepository : IRepository<Post>
    {
        public List<PostResponse> GetPostsByCache(string language, string urlServerImage, int take);
        public List<PostResponse> GetHotPostsByCache(string language, string urlServerImage, int take);
        public List<PostResponse> GetCollaborativeProgramsByCache(string language, string urlServerImage, int take);
        Task<PaginatedList<Post>> GetPosts(string language, string urlServerImage, string type, int? page, int pageSize);
        Task<PaginatedList<Post>> GetPostById(string slug, int? page, int pageSize);
        Task<List<PostModel>> GetPostDetail(string slug);
    }
}
