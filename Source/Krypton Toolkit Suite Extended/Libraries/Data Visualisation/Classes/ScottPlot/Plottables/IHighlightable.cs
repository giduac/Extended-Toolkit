﻿namespace Krypton.Toolkit.Suite.Extended.Data.Visualisation
{
    interface IHighlightable
    {
        (double x, double y, int index) GetPointNearestX(double x);
        (double x, double y, int index) GetPointNearestY(double y);
        (double x, double y, int index) GetPointNearest(double x, double y);

        (double x, double y, int index) HighlightPoint(int index);
        (double x, double y, int index) HighlightPointNearestX(double x);
        (double x, double y, int index) HighlightPointNearestY(double y);
        (double x, double y, int index) HighlightPointNearest(double x, double y);
        void HighlightClear();
    }
}