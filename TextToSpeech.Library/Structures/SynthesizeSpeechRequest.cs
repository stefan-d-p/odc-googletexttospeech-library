using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "The top-level message sent by the client for the `SynthesizeSpeech` method")]
public struct SynthesizeSpeechRequest
{
    [OSStructureField(Description = "The Synthesizer requires either plain text or SSML as input.",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public SynthesisInput Input;
    
    [OSStructureField(Description = "The desired voice of the synthesized audio",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public VoiceSelectionParams Voice;
    
    [OSStructureField(Description = "The audio encoding of the synthesized audio",
        DataType = OSDataType.InferredFromDotNetType,
        IsMandatory = true)]
    public AudioConfig AudioConfig;
}