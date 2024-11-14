using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "A Multi-speaker turn")]
public struct Turn
{
    [OSStructureField(Description = "Speaker of the turn",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Speaker;
    
    [OSStructureField(Description = "Text of the turn",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Text;
}