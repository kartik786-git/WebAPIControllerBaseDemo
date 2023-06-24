using WebApplication5.Model;

namespace WebApplication5.Services
{
    public interface IBlogService
    {
        List<Blog> GetAll();
        Blog GetById(int id);
        Blog Create(Blog blog);
        bool Update(int id, Blog blog);
        bool Delete(int id);
    }
}
