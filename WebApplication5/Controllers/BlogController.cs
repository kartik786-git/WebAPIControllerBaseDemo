using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication5.Model;
using WebApplication5.Services;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        //private readonly List<Blog> _blogs;
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
           // _blogs = new List<Blog>();
            _blogService = blogService;
        }

        [HttpGet]
        public ActionResult<List<Blog>> GetAll()
        {
            return _blogService.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Blog> GetById(int id)
        {
            var blog = _blogService.GetById(id);
            if (blog == null)
            {
                return NotFound();
            }
            return blog;
        }

        [HttpPost]
        public ActionResult<Blog> Create(Blog blog)
        {
           var createdBlog = _blogService.Create(blog);
            return CreatedAtAction(nameof(GetById), new { id = createdBlog.Id }, createdBlog);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Blog updatedBlog)
        {
            var existingBlog = _blogService.Update(id ,updatedBlog);
            if (!existingBlog)
            {
                return NotFound();
            }
           
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var blog = _blogService.Delete(id);
            if (!blog)
            {
                return NotFound();
            }
            return NoContent();
        }

      
    }
}
