using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace JsonEnumMemberName;

[Newtonsoft.Json.JsonConverter(typeof(StringEnumConverter))]
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum SampleEnum
{
    ValueOne = 1,
    [EnumMember(Value = "Value Two")]
    ValueTwo = 2,
}
