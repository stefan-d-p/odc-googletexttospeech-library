using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "Description of which voice to use for a synthesis request")]
public struct VoiceCloneParams
{
    [OSStructureField(Description = "Created by GenerateVoiceCloningKey.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string VoiceCloningKey;
}