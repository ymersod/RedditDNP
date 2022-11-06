using Shared.Dtos;
using Shared.Models;

namespace BlazorRedditFront.Services.Http;

public interface IPostService
{
    public Task<ICollection<PostBasicDto>> GetAllAsync();

    public Task CreatePostAsync(string title, string mainText, string nickName);

    public Task<PostFullDto> GetAsync(int id);

}