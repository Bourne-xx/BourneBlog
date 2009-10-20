using FluentNHibernate.Mapping;

namespace BourneBlog.App.Entities.Maps
{
    public class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.Title).Length(300);
            Map(x => x.Body).Length(10000);
            Map(x => x.PostDate);
        }
    }
}