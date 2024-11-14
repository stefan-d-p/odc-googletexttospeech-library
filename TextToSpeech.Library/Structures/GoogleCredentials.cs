using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech.Structures;

[OSStructure(Description = "Google Service Account Credentials")]
public struct GoogleCredentials
{
    
    [OSStructureField(Description = "Type of the credentia",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string Type;

    [OSStructureField(Description = "Project ID associated with this credential",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string ProjectId;

    [OSStructureField(Description = "Private Key ID",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string PrivateKeyId;

    [OSStructureField(Description = "Private Key",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string PrivateKey;

    [OSStructureField(Description = "Client Email",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string ClientEmail;

    [OSStructureField(Description = "Client ID",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string ClientId;
    
    [OSStructureField(Description = "Universe domain that this credential may be used in",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string UniverseDomain;
    
    [OSStructureField(Description = "The token endpoint for a service account credential",
        DataType = OSDataType.Text,
        IsMandatory = true)]
    public string TokenUri;
}
