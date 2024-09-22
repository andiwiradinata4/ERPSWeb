using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;
namespace ERPS.Infrastructure.Utilities
{
    public class Message
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public MessageType Type { get; }

        public string Code { get; }

        public string Description { get; }

        public string Field { get; } = string.Empty;


        public Message(MessageType type, string code, string description, string field = "")
        {
            Type = type;
            Code = code;
            Description = description;
            Field = field;
        }
    }
}
