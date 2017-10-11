using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace RabbitHutch.Web.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj)
        {
            var jsonSerializer =
                JsonSerializer.Create(new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore, 
                });

            var stringWriter = new StringWriter();
            jsonSerializer.Serialize(stringWriter, obj);

            return stringWriter.ToString();
        }
    }
}