using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "The configuration of the synthesized audio")]
public struct AudioConfig
{
    [OSStructureField(Description = "The format of the audio byte stream",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string AudioEncoding;
    
    
}