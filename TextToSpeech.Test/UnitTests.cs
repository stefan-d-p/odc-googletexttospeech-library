using Microsoft.Extensions.Configuration;
using Without.Systems.TextToSpeech.Structures;

namespace Without.Systems.TextToSpeech.Test;

public class Tests
{
    private static readonly ITextToSpeech _actions = new TextToSpeech();

    private const string Type = "service_account";
    private const string ProjectId = "outsystems-speech";
    private const string TokenUri = "https://oauth2.googleapis.com/token";
    private const string UniverseDomain = "googleapis.com";
    
    private string _privateKeyId;
    private string _privateKey;
    private string _clientId;
    private string _clientEmail;
    
    
    
    [SetUp]
    public void Setup()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .AddUserSecrets<Tests>()
            .AddEnvironmentVariables()
            .Build();

        _privateKeyId = configuration["GooglePrivateKeyId"] ?? throw new InvalidOperationException();
        _privateKey = configuration["GooglePrivateKey"] ?? throw new InvalidOperationException();
        _clientId = configuration["GoogleClientId"] ?? throw new InvalidOperationException();
        _clientEmail = configuration["GoogleClientEmail"] ?? throw new InvalidOperationException();
        
        
    }

    [Test]
    public void Simple_Standard_Voice_Synthesize()
    {
        GoogleCredentials credentials = new GoogleCredentials()
        {
            Type = Type,
            ProjectId = ProjectId,
            TokenUri = TokenUri,
            PrivateKeyId = _privateKeyId,
            PrivateKey = _privateKey,
            ClientId = _clientId,
            ClientEmail = _clientEmail,
            UniverseDomain = UniverseDomain
        };

        SynthesizeSpeechRequest request = new SynthesizeSpeechRequest()
        {
            Input = new SynthesisInput()
            {
                Text = "Just to see if this is working"
            },
            Voice = new VoiceSelectionParams()
            {
                Name = "en-US-Standard-E",
                LanguageCode = "en-US"
            },
            AudioConfig = new AudioConfig()
            {
                AudioEncoding = "Mp3"
            }
        };

        var response = _actions.SynthesizeSpeech(credentials,request);
     
    }
}