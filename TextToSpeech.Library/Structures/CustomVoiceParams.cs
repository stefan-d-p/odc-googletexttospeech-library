using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "Description of the custom voice to be synthesized")]
public struct CustomVoiceParams
{
    [OSStructureField(Description = "The name of the AutoML model that synthesizes the custom voice.",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string ModelName;

    [OSStructureField(Description = "Model resource name property",
        DataType = OSDataType.Text,
        IsMandatory = false)]
    public string ModelAsModelName;
}