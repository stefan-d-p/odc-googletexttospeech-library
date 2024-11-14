using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "Description of which voice to use for a synthesis request.")]
public struct VoiceSelectionParams
{
    [OSStructureField(
        Description =
            "The name of the voice. If both the name and the gender are not set, the service will choose a voice based on the other parameters such as language_code.",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Name;
    
    [OSStructureField(Description = "Required. The language (and potentially also the region) of the voice expressed as a language tag, e. g. en-US",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string LanguageCode;

    [OSStructureField(Description = "The configuration for a voice clone.",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public VoiceCloneParams VoiceClone;
    
    [OSStructureField(Description = "The configuration for a custom voice",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public CustomVoiceParams CustomVoice;
    
    [OSStructureField(Description = "The preferred gender of the voice",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string SsmlGender;
}