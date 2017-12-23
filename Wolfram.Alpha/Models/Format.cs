using System.Collections.Generic;

namespace Wolfram.Alpha.Models
{
    public static class Format
    {
        public const string Plaintext = "plaintext";
        public const string Image = "image";
        public const string ImageMap = "imagemap";
        public const string MathematicaCell = "cell";
        public const string MathML = "mathml";
        public const string MathematicaInput = "minput";
        public const string MathematicaOutput = "moutput";
        public const string Sound = "sound";
        public const string Wav = "sound";

        public static List<string> WolframAlphaCommon() => new List<string>
        {
            Image, Plaintext, Image, ImageMap, Sound, MathematicaInput, MathematicaOutput
        };

        public static List<string> All() => new List<string>
        {
            Plaintext, Image, ImageMap, MathematicaCell, MathML, MathematicaInput, MathematicaOutput, Sound, Wav
        };
    }
}
