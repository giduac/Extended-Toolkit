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
    public static class Marker
    {
        // TODO: refactor this in the next major version of ScottPlot to add support for LineWidth, etc
        public static MarkerShape None => MarkerShape.None;
        public static MarkerShape FilledCircle => MarkerShape.FilledCircle;
        public static MarkerShape OpenCircle => MarkerShape.OpenCircle;
        public static MarkerShape FilledSquare => MarkerShape.FilledSquare;
        public static MarkerShape OpenSquare => MarkerShape.OpenSquare;
        public static MarkerShape FilledDiamond => MarkerShape.FilledDiamond;
        public static MarkerShape OpenDiamond => MarkerShape.OpenDiamond;
        public static MarkerShape Asterisk => MarkerShape.Asterisk;
        public static MarkerShape HashTag => MarkerShape.HashTag;
        public static MarkerShape Cross => MarkerShape.Cross;
        public static MarkerShape Eks => MarkerShape.Eks;
        public static MarkerShape VerticalBar => MarkerShape.VerticalBar;
        public static MarkerShape TriangleUp => MarkerShape.TriUp;
        public static MarkerShape TriangleDown => MarkerShape.TriDown;

        public static MarkerShape Random() => Random(new Random());

        public static MarkerShape Random(Random rand)
        {
            Array members = Enum.GetValues(typeof(MarkerShape));
            object randomMember = members.GetValue(rand.Next(members.Length));
            return (MarkerShape)randomMember;
        }
    }
}