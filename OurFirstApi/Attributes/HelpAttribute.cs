using Newtonsoft.Json;

namespace OurFirstApi.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property)]


public class HelpAttribute : Attribute
{
    public HelpAttribute(string url)
    {
        Url = url;
    }
    [JsonProperty("")]
    public string Url { get; set; }
    
}