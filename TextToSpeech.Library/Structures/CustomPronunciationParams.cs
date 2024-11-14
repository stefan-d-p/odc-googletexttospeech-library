using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "Pronunciation customization for a phrase")]
public struct CustomPronunciationParams
{
    [OSStructureField(Description = "The phrase the customization will be applied to",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Phrase;
    
    [OSStructureField(Description = "The pronunciation to be applied to the phrase",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Pronunciation;
    
    
}