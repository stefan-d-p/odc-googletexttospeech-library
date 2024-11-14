using AutoMapper;
using Google.Api.Gax.Grpc;
using Google.Api.Gax.Grpc.Rest;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.TextToSpeech.V1Beta1;
using Google.Protobuf.Collections;
using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech;

public class TextToSpeech : ITextToSpeech
{

    private readonly IMapper _mapper;

    public TextToSpeech()
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Structures.GoogleCredentials, JsonCredentialParameters>()
                .ForMember(dest => dest.PrivateKey,
                    opt => opt.MapFrom(src => src.PrivateKey
                        .Replace("\n", Environment.NewLine)
                        .Replace("\\n", Environment.NewLine)
                        .Replace("\r\n", Environment.NewLine)));
           
            cfg.CreateMap<Structures.Turn, MultiSpeakerMarkup.Types.Turn>();
            cfg.CreateMap<Structures.MultiSpeakerMarkup, MultiSpeakerMarkup>()
                .ForMember(dest => dest.Turns, opt => opt.Condition(src => src.Turns is { Count: > 0 }));
            cfg.CreateMap<Structures.SynthesizeSpeechRequest, SynthesizeSpeechRequest>();
            cfg.CreateMap<Structures.SynthesisInput, SynthesisInput>()
                .ForMember(dest => dest.Ssml, opt => opt.Ignore())
                .ForMember(dest => dest.Text, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    /*
                     * Due to the oneof constraint of the protobuf generated class
                     * I could only sucessfully map the values in AfterMap
                     */
                    
                    if (!string.IsNullOrEmpty(src.Text))
                    {
                        dest.Text = src.Text;
                    }
                    else if (!string.IsNullOrEmpty(src.Ssml))
                    {
                        dest.Ssml = src.Ssml;
                    }
                });

            cfg.CreateMap<Structures.VoiceCloneParams, VoiceCloneParams>()
                .ForMember(dest => dest.VoiceCloningKey,
                    opt => opt.Condition(src => !string.IsNullOrEmpty(src.VoiceCloningKey)));
            cfg.CreateMap<Structures.VoiceSelectionParams, VoiceSelectionParams>()
                .ForMember(dest => dest.Name, opt => opt.Condition(src => !string.IsNullOrEmpty(src.Name)))
                .ForMember(dest => dest.SsmlGender, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.SsmlGender));
                    opt.MapFrom(src => ParseSsmlVoiceGender(src.SsmlGender));
                });

            cfg.CreateMap<Structures.CustomVoiceParams, CustomVoiceParams>()
                .ForMember(dest => dest.ModelAsModelName, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.ModelAsModelName));
                    opt.MapFrom(src => ModelName.Parse(src.ModelAsModelName));
                });
            
            cfg.CreateMap<Structures.AudioConfig, AudioConfig>()
                .ForMember(dest => dest.AudioEncoding, opt =>
                {
                    opt.PreCondition(src => !string.IsNullOrEmpty(src.AudioEncoding));
                    opt.MapFrom(src => ParseAudioEncoding(src.AudioEncoding));
                });

            cfg.CreateMap<AudioConfig, Structures.AudioConfig>();
            cfg.CreateMap<SynthesizeSpeechResponse, Structures.SynthesizeSpeechResponse>()
                .ForMember(dest => dest.AudioContent, opt => opt.MapFrom(src => src.AudioContent.ToByteArray()));

        });
        _mapper = mapperConfiguration.CreateMapper();
    }
    
    public Structures.SynthesizeSpeechResponse SynthesizeSpeech(Structures.GoogleCredentials credentials, Structures.SynthesizeSpeechRequest request)
    {
        TextToSpeechClient client = GetClient(credentials);
        SynthesizeSpeechRequest synthesizeSpeechRequest = _mapper.Map<SynthesizeSpeechRequest>(request);

        var response = client.SynthesizeSpeech(synthesizeSpeechRequest);

        return _mapper.Map<Structures.SynthesizeSpeechResponse>(response);
    }
    
    private TextToSpeechClient GetClient(Structures.GoogleCredentials credentials)
    {
        JsonCredentialParameters jsonCredentialParameters = _mapper.Map<JsonCredentialParameters>(credentials);
        GoogleCredential googleCredentials = GoogleCredential.FromJsonParameters(jsonCredentialParameters);

        TextToSpeechClient client = new TextToSpeechClientBuilder
        {
            GoogleCredential = googleCredentials,
            UserAgent = "OutSystems",
            GrpcAdapter = RestGrpcAdapter.Default
        }.Build();

        return client;

    }

    private SsmlVoiceGender ParseSsmlVoiceGender(string ssmlGender)
    {
        if (Enum.TryParse(ssmlGender, true, out SsmlVoiceGender parsedGender))
        {
            return parsedGender;
        }

        throw new Exception("Invalid Ssml Voice Gender");
    }
    
    private AudioEncoding ParseAudioEncoding(string audioEncoding)
    {
        if (Enum.TryParse(audioEncoding, true, out AudioEncoding parsedAudioEncoding))
        {
            return parsedAudioEncoding;
        }

        throw new Exception("Invalid Audio Encoding");
    }
}