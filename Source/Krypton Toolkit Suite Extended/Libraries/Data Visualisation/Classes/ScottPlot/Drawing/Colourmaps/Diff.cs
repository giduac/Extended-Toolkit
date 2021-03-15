﻿#region BSD License
/*
 * Use of this source code is governed by a BSD-style
 * license or other governing licenses that can be found in the LICENSE.md file or at
 * https://raw.githubusercontent.com/Krypton-Suite/Extended-Toolkit/master/LICENSE
 */
#endregion

namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    public class Diff : IColourmap
    {
        public (byte r, byte g, byte b) GetRGB(byte value) =>
            (cmaplocal[value, 0], cmaplocal[value, 1], cmaplocal[value, 2]);

        private static readonly byte[,] cmaplocal = {
            { 8, 35, 64 },
            { 9, 37, 66 },
            { 10, 38, 68 },
            { 11, 40, 69 },
            { 12, 42, 71 },
            { 12, 44, 73 },
            { 13, 45, 75 },
            { 14, 47, 77 },
            { 15, 49, 79 },
            { 16, 50, 81 },
            { 17, 52, 83 },
            { 17, 54, 85 },
            { 18, 55, 86 },
            { 19, 57, 88 },
            { 20, 59, 90 },
            { 20, 61, 92 },
            { 21, 62, 94 },
            { 22, 64, 95 },
            { 23, 66, 97 },
            { 24, 67, 99 },
            { 25, 69, 100 },
            { 26, 71, 102 },
            { 27, 72, 103 },
            { 29, 74, 104 },
            { 31, 76, 105 },
            { 33, 77, 106 },
            { 36, 79, 107 },
            { 38, 80, 108 },
            { 40, 82, 109 },
            { 43, 83, 110 },
            { 45, 85, 111 },
            { 47, 86, 112 },
            { 49, 88, 113 },
            { 52, 89, 115 },
            { 54, 91, 116 },
            { 56, 92, 117 },
            { 58, 94, 118 },
            { 60, 95, 119 },
            { 62, 97, 120 },
            { 65, 98, 121 },
            { 67, 100, 122 },
            { 69, 101, 123 },
            { 71, 103, 125 },
            { 73, 104, 126 },
            { 75, 106, 127 },
            { 77, 107, 128 },
            { 79, 109, 129 },
            { 81, 110, 130 },
            { 83, 112, 132 },
            { 85, 113, 133 },
            { 88, 115, 134 },
            { 90, 116, 135 },
            { 92, 118, 136 },
            { 94, 120, 138 },
            { 96, 121, 139 },
            { 98, 123, 140 },
            { 100, 124, 141 },
            { 102, 126, 142 },
            { 104, 127, 144 },
            { 106, 129, 145 },
            { 108, 130, 146 },
            { 110, 132, 148 },
            { 112, 134, 149 },
            { 114, 135, 150 },
            { 116, 137, 151 },
            { 118, 138, 153 },
            { 120, 140, 154 },
            { 123, 141, 155 },
            { 125, 143, 157 },
            { 127, 145, 158 },
            { 129, 146, 159 },
            { 131, 148, 161 },
            { 133, 150, 162 },
            { 135, 151, 163 },
            { 137, 153, 165 },
            { 139, 154, 166 },
            { 141, 156, 167 },
            { 143, 158, 169 },
            { 146, 159, 170 },
            { 148, 161, 172 },
            { 150, 163, 173 },
            { 152, 165, 175 },
            { 154, 166, 176 },
            { 156, 168, 177 },
            { 158, 170, 179 },
            { 160, 171, 180 },
            { 163, 173, 182 },
            { 165, 175, 183 },
            { 167, 177, 185 },
            { 169, 178, 186 },
            { 171, 180, 188 },
            { 174, 182, 189 },
            { 176, 184, 191 },
            { 178, 186, 192 },
            { 180, 187, 194 },
            { 182, 189, 196 },
            { 185, 191, 197 },
            { 187, 193, 199 },
            { 189, 195, 200 },
            { 191, 197, 202 },
            { 194, 198, 204 },
            { 196, 200, 205 },
            { 198, 202, 207 },
            { 200, 204, 209 },
            { 203, 206, 210 },
            { 205, 208, 212 },
            { 207, 210, 214 },
            { 210, 212, 215 },
            { 212, 214, 217 },
            { 214, 216, 219 },
            { 217, 218, 221 },
            { 219, 220, 222 },
            { 221, 222, 224 },
            { 224, 224, 226 },
            { 226, 226, 227 },
            { 228, 227, 229 },
            { 230, 229, 231 },
            { 232, 231, 232 },
            { 235, 233, 234 },
            { 236, 234, 235 },
            { 238, 236, 236 },
            { 240, 237, 238 },
            { 241, 238, 239 },
            { 243, 239, 239 },
            { 244, 240, 240 },
            { 245, 241, 240 },
            { 245, 241, 240 },
            { 246, 241, 240 },
            { 246, 241, 240 },
            { 245, 241, 239 },
            { 245, 240, 238 },
            { 244, 239, 237 },
            { 243, 238, 235 },
            { 242, 237, 233 },
            { 241, 235, 232 },
            { 239, 234, 229 },
            { 238, 232, 227 },
            { 236, 230, 225 },
            { 234, 229, 223 },
            { 232, 227, 220 },
            { 231, 225, 218 },
            { 229, 223, 215 },
            { 227, 221, 212 },
            { 225, 219, 210 },
            { 223, 217, 207 },
            { 221, 215, 205 },
            { 219, 213, 202 },
            { 217, 211, 199 },
            { 215, 209, 197 },
            { 213, 207, 194 },
            { 211, 205, 192 },
            { 210, 203, 189 },
            { 208, 201, 187 },
            { 206, 199, 184 },
            { 204, 197, 181 },
            { 202, 195, 179 },
            { 200, 193, 176 },
            { 199, 191, 174 },
            { 197, 189, 171 },
            { 195, 187, 169 },
            { 193, 185, 166 },
            { 191, 183, 164 },
            { 190, 181, 161 },
            { 188, 179, 159 },
            { 186, 177, 157 },
            { 185, 176, 154 },
            { 183, 174, 152 },
            { 181, 172, 149 },
            { 179, 170, 147 },
            { 178, 168, 144 },
            { 176, 166, 142 },
            { 174, 165, 140 },
            { 173, 163, 137 },
            { 171, 161, 135 },
            { 169, 159, 133 },
            { 168, 157, 130 },
            { 166, 156, 128 },
            { 164, 154, 125 },
            { 163, 152, 123 },
            { 161, 150, 121 },
            { 160, 149, 118 },
            { 158, 147, 116 },
            { 156, 145, 114 },
            { 155, 143, 112 },
            { 153, 142, 109 },
            { 152, 140, 107 },
            { 150, 138, 105 },
            { 149, 137, 103 },
            { 147, 135, 100 },
            { 145, 133, 98 },
            { 144, 132, 96 },
            { 142, 130, 94 },
            { 141, 128, 91 },
            { 139, 127, 89 },
            { 138, 125, 87 },
            { 136, 123, 85 },
            { 135, 122, 83 },
            { 133, 120, 80 },
            { 131, 118, 78 },
            { 130, 117, 76 },
            { 128, 115, 74 },
            { 127, 114, 72 },
            { 125, 112, 70 },
            { 124, 110, 67 },
            { 122, 109, 65 },
            { 121, 107, 63 },
            { 119, 106, 61 },
            { 118, 104, 59 },
            { 116, 102, 57 },
            { 114, 101, 55 },
            { 113, 99, 53 },
            { 111, 98, 51 },
            { 110, 96, 48 },
            { 108, 95, 46 },
            { 106, 93, 44 },
            { 104, 92, 43 },
            { 103, 90, 41 },
            { 101, 89, 39 },
            { 99, 88, 38 },
            { 97, 86, 37 },
            { 95, 85, 36 },
            { 93, 84, 35 },
            { 91, 82, 34 },
            { 89, 81, 33 },
            { 87, 79, 32 },
            { 85, 78, 32 },
            { 83, 77, 31 },
            { 81, 75, 30 },
            { 79, 74, 29 },
            { 77, 72, 29 },
            { 75, 71, 28 },
            { 73, 69, 27 },
            { 71, 68, 26 },
            { 69, 67, 26 },
            { 67, 65, 25 },
            { 66, 64, 24 },
            { 64, 62, 23 },
            { 62, 61, 22 },
            { 60, 59, 22 },
            { 58, 58, 21 },
            { 56, 57, 20 },
            { 54, 55, 19 },
            { 52, 54, 18 },
            { 51, 52, 18 },
            { 49, 51, 17 },
            { 47, 49, 16 },
            { 45, 48, 15 },
            { 43, 46, 14 },
            { 41, 45, 13 },
            { 39, 43, 12 },
            { 38, 42, 11 },
            { 36, 40, 10 },
            { 34, 39, 9 },
            { 32, 37, 9 },
            { 30, 36, 8 },
            { 28, 34, 7 }

        };
    }
}