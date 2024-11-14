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
                MultiSpeakerMarkup = new MultiSpeakerMarkup()
                {
                    Turns = new List<Turn>()
                    {
                        new Turn()
                        {
                            Text = "Absolutely. There are several key challenges. First, you're limited by the Server Request Timeout setting, which is a maximum of 60 seconds in ODC. This can cause issues with larger file uploads. There's also a 28MB limit on request payloads. Additionally, ODC doesn't support File Streams and Byte Range Requests, which affects streaming capabilities and user experience. Memory usage can also be a problem when fetching many large files simultaneously.",
                            Speaker = "R"
                        }
                    }
                }
            },
            Voice = new VoiceSelectionParams()
            {
                Name = "en-US-Studio-MultiSpeaker",
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