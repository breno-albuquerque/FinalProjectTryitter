using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Entities;
using Tryitter.Repository;
using Tryitter.Transport;

namespace Tryitter.Controllers
{
    [ApiController]
    [Route("post")]
    public class PostsController : Controller
    {
        private readonly ITryitterRepository _tryitterRepository;

        public PostsController(ITryitterRepository tryitterRepository)
        {
            _tryitterRepository = tryitterRepository;
        }

        [HttpPost]
        [Authorize]
        public IActionResult CreatePost(CreatePostRequest request)
        {
            Post post = new()
            {
                Image = request.Image,
                Text = request.Post
            };

            _tryitterRepository.CreatePost(post);

            return Ok(post);
            //return CreatedAtAction(nameof(CreatePost), new { id = request.StudentId }, post);
        }

        [HttpGet("{id}")]
        public IActionResult GetPost(int postId)
        {
            var post = _tryitterRepository.GetPost(postId);

            if (post == null)
            {
                return NotFound(new { Message = "Usuário não encontrado" });
            }

            return Ok(post);
        }

        //[HttpGet]
        //public ActionResult<IEnumerable<Post>> Get()
        //{
        //    var posts = _tryitterRepository.Posts.AsNoTracking().Take(10).ToList();

        //    if (posts is null)
        //    {
        //        return NotFound("Posts não encontrados");
        //    }
        //    return posts;
        //}
    }
}