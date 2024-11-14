using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "Synthesize Speech Response")]
public struct SynthesizeSpeechResponse
{
    [OSStructureField(Description = "The audio metadata",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = false)]
    public AudioConfig AudioConfig;
}