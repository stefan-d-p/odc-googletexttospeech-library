using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "Custom pronunciation settings")]
public struct CustomPronunciations
{
    [OSStructureField(Description = "The pronunciation customizations to apply",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public List<CustomPronunciationParams> Pronunciations;
}