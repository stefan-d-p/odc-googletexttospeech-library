using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "Synthesis Input")]
public struct SynthesisInput
{
    [OSStructureField(Description = "Text to synthesize",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Text;

    [OSStructureField(Description = "SSML to synthesize",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string Ssml;
    
    [OSStructureField(Description = "Multispeaker Markup",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public MultiSpeakerMarkup MultiSpeakerMarkup;

}