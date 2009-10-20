using System.Web.Mvc;
using BourneBlog.App.Entities;
using BourneFramework.Repository;

namespace BourneBlog.App.Controllers
{
    public class PostController : Controller
    {
        private readonly IRepository<Post> _repository;

        public PostController(IRepository<Post> repository)
        {
            _repository = repository;
        }

        public ActionResult Latest()
        {
            var posts = _repository.GetAll<Post>();
            return View(posts);
        }

    }
}