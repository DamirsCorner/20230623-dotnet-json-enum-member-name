using FluentAssertions;
using System.Text.Json;

namespace JsonEnumMemberName;

public class SerializationTests
{
    [Test]
    public void NewtonsoftJsonReadsEnumMemberAttribute()
    {
        var original = new SampleObject
        {
            Value = SampleEnum.ValueTwo,
        };

        var json = Newtonsoft.Json.JsonConvert.SerializeObject(original);

        json.Should().Be("""{"Value":"Value Two"}""");

        var deserialized = Newtonsoft.Json.JsonConvert.DeserializeObject<SampleObject>(json);

        deserialized.Should().BeEquivalentTo(original);
    }

    [Test]
    public void SystemTextJsonCustomConverterReadsEnumMemberAttribute()
    {
        var original = new SampleObject
        {
            Value = SampleEnum.ValueTwo,
        };

        var json = JsonSerializer.Serialize(original);

        json.Should().Be("""{"Value":"Value Two"}""");

        var deserialized = JsonSerializer.Deserialize<SampleObject>(json);

        deserialized.Should().BeEquivalentTo(original);
    }
}