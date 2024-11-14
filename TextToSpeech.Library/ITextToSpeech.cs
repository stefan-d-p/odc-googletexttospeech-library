using OutSystems.ExternalLibraries.SDK;

namespace Without.Systems.TextToSpeech
{
    [OSInterface(
        Name = "GoogleTextToSpeech",
        Description = "Convert text into natural-sounding speech using an API powered by the best of Google’s AI technologies.",
        IconResourceName = "Without.Systems.TextToSpeech.Resources.TextToSpeech.png")]
    public interface ITextToSpeech
    {

        [OSAction(
            Description = "Synthesizes speech synchronously",
            ReturnName = "result",
            ReturnDescription = "Structure with audio configuration and binary data of the synthesized text",
            ReturnType = OSDataType.InferredFromDotNetType,
            IconResourceName = "Without.Systems.TextToSpeech.Resources.TextToSpeech.png")]
        Structures.SynthesizeSpeechResponse SynthesizeSpeech(
            [OSParameter(
                Description = "Google credentials from credential file",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.GoogleCredentials credentials,
            [OSParameter(
                Description = "Speech Synthesis input parameters",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.SynthesizeSpeechRequest request,
            [OSParameter(
                Description = "Output Configuration",
                DataType = OSDataType.InferredFromDotNetType)]
            Structures.Output outputConfig);
        
    }
}