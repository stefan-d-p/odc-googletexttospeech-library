using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "A collection of turns for multi-speaker synthesis.")]
public struct MultiSpeakerMarkup
{
    [OSStructureField(Description = "Speaker turns",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public List<Turn> Turns;
}