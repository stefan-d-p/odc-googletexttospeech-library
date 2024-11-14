# Google Text-To-Speech ODC Connector

This OutSystems Developer Cloud external logic connector wraps the Google Text-To-Speech SDK for .net
for speech synthetization.

## SynthesizeSpeech

Synthesizes speech synchronously and returns the generated audio file as binary data

Input

* `SynthesisInput` - Structure to define text or ssml for synthetization
* `VoiceSelectionParams` - Configuration of language and voice to use
* `AudioConfig` - Configuration of the audio encoding.

Output

* `AudioConfig` - Configuration of the audio encoding.
* `AudioContent` - The result audio binary data

Regarding detailled configuration see [Google Text-to-Speech Documentation](https://cloud.google.com/text-to-speech/docs/reference/rpc/google.cloud.texttospeech.v1beta1).
