using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "Output Configuration")]
public struct Output
{
    [OSStructureField(Description = "Type of output storage. Currently supports S3 only",
        DataType = OSDataType.Text,
        DefaultValue = "S3",
        IsMandatory = false)]
    public string Type;
    
    [OSStructureField(Description = "Output Pre-Signed Url",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string PreSignedUrl;
}