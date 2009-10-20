using System;

namespace BourneBlog.App.Entities
{
    public class Post
    {
        public virtual long? Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual DateTime? PostDate { get; set; }
    }
}