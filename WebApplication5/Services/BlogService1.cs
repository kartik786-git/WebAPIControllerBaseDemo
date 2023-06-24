using WebApplication5.Model;

namespace WebApplication5.Services
{
    public class BlogService : IBlogService
    {
        private readonly List<Blog> _blogs;
        public BlogService()
        {
            _blogs = new List<Blog>();
        }
        public Blog Create(Blog blog)
        {
            blog.Id = GenerateNewId();
            _blogs.Add(blog);
            return blog;
        }

        public bool Delete(int id)
        {
            var blog = _blogs.FirstOrDefault(item => item.Id == id);
            if (blog == null)
            {
                return false;
            }
            _blogs.Remove(blog);
            return true;
        }

        public List<Blog> GetAll()
        {
            return _blogs;
        }

        public Blog GetById(int id)
        {
            var blog = _blogs.FirstOrDefault(item => item.Id == id);
            if (blog == null)
            {
                return null;
            }
            return blog;
        }

        public bool Update(int id, Blog blog)
        {
            var existingBlog = _blogs.FirstOrDefault(item => item.Id == id);
            if (existingBlog == null)
            {
                return false;
            }
            existingBlog.Title = blog.Title;
            existingBlog.Description = blog.Description;
            return true;
        }

        private int GenerateNewId()
        {
            if (_blogs.Count > 0)
            {
                return _blogs.Max(item => item.Id) + 1;
            }
            return 1;
        }
    }
}