﻿#region MIT License
/*
 * MIT License
 *
 * Copyright (c) 2017 - 2024 Krypton Suite
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 *
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation.ScottPlot
{
    public class Blues : IColourMap
    {
        public string Name => "Blues";

        public (byte r, byte g, byte b) GetRGB(byte value)
        {
            byte[] bytes = BitConverter.GetBytes(argb[value]);
            return (bytes[2], bytes[1], bytes[0]);
        }

        private readonly int[] argb =
        {
            -16767403, -16767402, -16767144, -16766887, -16701093, -16700835, -16700578, -16634784,
            -16634527, -16634269, -16568476, -16568218, -16568216, -16567959, -16502165, -16501908,
            -16501650, -16435856, -16435599, -16435341, -16369548, -16369290, -16369033, -16303495,
            -16303238, -16302980, -16237186, -16236929, -16236671, -16236414, -16170620, -16170363,
            -16170105, -16104312, -16104054, -16103797, -16038259, -16038002, -16037745, -15971951,
            -15971694, -15971436, -15905643, -15905385, -15905128, -15839335, -15839077, -15838820,
            -15773027, -15772769, -15772512, -15706718, -15706717, -15706460, -15706203, -15640409,
            -15640152, -15574359, -15574101, -15573844, -15508051, -15507794, -15507537, -15441743,
            -15441486, -15441229, -15375436, -15375179, -15309386, -15309128, -15308871, -15243078,
            -15242821, -15177284, -15177027, -15111234, -15110977, -15045184, -15044927, -14979134,
            -14978877, -14913084, -14912827, -14847034, -14781241, -14780984, -14715191, -14715190,
            -14649397, -14583605, -14517812, -14517555, -14451762, -14385969, -14320176, -14319920,
            -14254383, -14188590, -14122797, -14057005, -13991212, -13925419, -13859626, -13859626,
            -13793833, -13662505, -13596712, -13530919, -13465383, -13399590, -13333797, -13268005,
            -13202212, -13136676, -13005347, -12939555, -12873762, -12808226, -12676897, -12611105,
            -12545312, -12414240, -12348447, -12282655, -12151327, -12085790, -12019998, -11888669,
            -11822877, -11757341, -11626012, -11560220, -11429148, -11363355, -11232027, -11166235,
            -11035162, -10969370, -10903578, -10772505, -10706713, -10575385, -10509592, -10378520,
            -10312728, -10181400, -10115863, -09984535, -09918743, -09787414, -09721878, -09590550,
            -09524758, -09393429, -09327893, -09262101, -09130773, -09065237, -08933908, -08868116,
            -08736788, -08671252, -08605459, -08474131, -08408339, -08277267, -08211475, -08145682,
            -08014354, -07948818, -07817490, -07751698, -07685905, -07554833, -07489041, -07357713,
            -07291921, -07226128, -07095056, -07029264, -06897936, -06832144, -06766351, -06635279,
            -06569487, -06503695, -06372367, -06306575, -06175502, -06109710, -06043918, -05912590,
            -05846798, -05781261, -05649933, -05584141, -05518349, -05387021, -05321485, -05190156,
            -05124364, -05058572, -04927244, -04861452, -04730123, -04664587, -04598795, -04467467,
            -04401675, -04335883, -04204554, -04139018, -04007690, -03941898, -03876106, -03744777,
            -03678985, -03547657, -03481865, -03416329, -03285000, -03219208, -03087880, -03022088,
            -02956296, -02824968, -02759175, -02628103, -02562311, -02430983, -02365191, -02299398,
            -02168070, -02102278, -01970950, -01905158, -01839621, -01708293, -01642501, -01511173,
            -01445381, -01314052, -01248260, -01182468, -01051140, -00985604, -00854275, -00788483,
            -00657155, -00591363, -00525571, -00394242, -00328450, -00197122, -00131330, -00000001,
        };
    }
}
