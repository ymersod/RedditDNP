using ServerLogic.Daos;
using Shared.Dtos;
using Shared.Models;

namespace ServerLogic.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;

    public PostLogic(IPostDao postDao)
    {
        this.postDao = postDao;
    }
    
    public async Task<RedditPost> CreatePostDtoAsync(PostCreationDto postToCreate)
    {
        RedditPost post = new RedditPost()
        {
            PostTitle = postToCreate.PostTitle,
            PostContext = postToCreate.PostContext,
            PostCreator = postToCreate.NickName,
            Date = DateTime.Now
        };

        RedditPost createdPost = await postDao.CreateNewPostAsync(post);

        return createdPost;
    }

    public async Task<IEnumerable<PostBasicDto>> GetAllAsync()
    {
        IEnumerable<RedditPost>? posts = await postDao.GetAllPostsAsync();


        List<PostBasicDto>? postFullDtos = new List<PostBasicDto>();
        foreach (var post in posts)
        {
            postFullDtos.Add(new PostBasicDto
            {
                PostTitle = post.PostTitle,
                index = post.index
            });
        }
        return postFullDtos;
    }

    public async Task<PostFullDto> GetAsync(SelectedPostDto postDto)
    {

        RedditPost? redditpost = await postDao.GetAsync(postDto.id);

        return new PostFullDto
        {
            PostTitle = redditpost.PostTitle,
            PostContext = redditpost.PostContext,
            PostCreator = redditpost.PostCreator,
            Date = redditpost.Date,
            index = redditpost.index
        };
    }
}