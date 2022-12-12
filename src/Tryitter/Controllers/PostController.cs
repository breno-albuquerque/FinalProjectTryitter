using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Entities;
using Tryitter.Repository;
using Tryitter.Transport;

namespace Tryitter.Controllers
{
  [ApiController]
  [Route("posts")]
  public class PostsController : Controller
  {
    private readonly ITryitterRepository _tryitterRepository;

    public PostsController(ITryitterRepository tryitterRepository)
    {
        _tryitterRepository = tryitterRepository;
    }

    [HttpPost("post")]
    [Authorize]
    public IActionResult CreatePost(CreatePostRequest request)
    {
      Post post = new() { 
        StudentId = request.StudentId,        
        Images = request.Images,
        Text = request.Post };

      _tryitterRepository.CreatePost(post);

      return CreatedAtAction(nameof(CreatePost), new { id = StudentId }, post);
    }

    [HttpGet("{id}")]
        public IActionResult AllPosts(int postId)
        {
            var posts = _tryitterRepository.GetPost(postId);
            if (posts == null)
            {
                return NotFound(new { Message = "Usuário não encontrado" });
            }
            return Ok(posts);
        }

    [HttpGet]
    public ActionResult<IEnumerable<Post>> Get()
    {
      var posts = _tryitterRepository.Posts.AsNoTracking().Take(10).ToList();

      if(posts is null)
      {
        return NotFound("Posts não encontrados");
      }
      return posts;
    }
  }
}