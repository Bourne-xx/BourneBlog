using System.Web.Mvc;
using BourneFramework.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace BourneBlog.App.Controllers
{
    public class DbController : Controller
    {
        public string Create()
        {
            var schema = Config.NHSchema;
            var export = new SchemaExport(schema);
            export.Execute(true, true, false);
            return "success";
        }
    }
}