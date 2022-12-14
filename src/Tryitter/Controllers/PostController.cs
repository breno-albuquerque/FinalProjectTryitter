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
        public IActionResult CreatePost(PostRequest request)
        {

            var loggedStudentId = int.Parse(User.Claims.FirstOrDefault().Value);

            Post post = new()
            {
                StudentId = loggedStudentId,
                Image = request.Image,
                Text = request.Post
            };

            _tryitterRepository.CreatePost(post);

            return CreatedAtAction(nameof(CreatePost), new { id = loggedStudentId }, post);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public IActionResult GetPost([FromRoute] int id)
        {
            try
            {
                var post = _tryitterRepository.GetPost(id);

                return Ok(post);
            }
            catch (InvalidOperationException e)
            {
                return NotFound(e.Message);
            }

        }

        [HttpPut("{id}")]
        [Authorize]
        public IActionResult UpdatePost([FromRoute] int id, [FromBody] PostRequest request)
        {
            try
            {
                var loggedStudentId = int.Parse(User.Claims.FirstOrDefault().Value);

                Post post = new()
                {
                    StudentId = loggedStudentId,
                    Image = request.Image,
                    Text = request.Post
                };

                _tryitterRepository.UpdatePost(id, post);

                return Ok(post);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult DeletePost([FromRoute] int id)
        {
            try
            {
                var loggedStudentId = int.Parse(User.Claims.FirstOrDefault().Value);

                _tryitterRepository.DeletePost(id, loggedStudentId);

                return NoContent();
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}