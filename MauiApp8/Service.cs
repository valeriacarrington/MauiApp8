namespace MauiApp8;

public class Service
{
    public string Name { get; set; }
    public string Annotation { get; set; }
    public string Type { get; set; }
    public string Version { get; set; }
    public string Author { get; set; }
    public string UsageConditions { get; set; }
    public string RegistrationInfo { get; set; }

    public string Print()
    {
        var result =
            $"Name:{Name}\nAnnotation:{Annotation}\nType:{Type}\nVersion:{Version}\nAuthor:{Author}\nUsageConditions:{UsageConditions}\nRegistrationInfo:{RegistrationInfo}";
        return result;
    }
}