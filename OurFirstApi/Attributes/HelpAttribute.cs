using Newtonsoft.Json;

namespace OurFirstApi.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property)]
//NERELERDE KULLANILAB�LECE��NE DA�R KISITLAMA VERMEK ���N YAZILIR.


public class HelpAttribute : Attribute
{
    public HelpAttribute(string url)
    {
        Url = url;
    }
    [JsonProperty("")]
    public string Url { get; set; }
    
}