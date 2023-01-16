using Newtonsoft.Json;

namespace OurFirstApi.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property)]
//NERELERDE KULLANILABÝLECEÐÝNE DAÝR KISITLAMA VERMEK ÝÇÝN YAZILIR.


public class HelpAttribute : Attribute
{
    public HelpAttribute(string url)
    {
        Url = url;
    }
    [JsonProperty("")]
    public string Url { get; set; }
    
}