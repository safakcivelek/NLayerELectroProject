using NLayer.Core.Entities.Abstract;

namespace NLayer.Core.OtherEntities
{
    /* Log Yönetimi için eklediğim paketler; NLayer.Web
     * NLog v.4.7.7
     * NLog.Web.AspNetCore v.4.10.0
     * System.Data.SqlClient 
     * Sonrasında ise NLayer.Web projeme nlog.config dosyası oluşturuyorum.
     * https://github.com/NLog/NLog/wiki/Getting-started-with-ASP.NET-Core-5 bu link yarımı ile nlog.config dosyasını dolduruyorum.
     * Sonrasında porgram.cs üzerinde Nlog kullanmak istediğimi belirtmem gerekiyor.
     */
    public class Log:IEntity
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public DateTime Logged { get; set; }
        public string Level { get; set; }
        public string Message { get; set; }
        public string Logger { get; set; }
        public string Callsite { get; set; }
        public string Exception { get; set; }
    }
}
