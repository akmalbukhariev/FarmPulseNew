using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microcharts;
using SkiaSharp;

namespace FarmPulse.Control
{
    class FarmBarChart : BarChart
    {
        public IEnumerable<ChartEntry> NdviEntires = new List<ChartEntry>();

        private bool initiated = false;
        private float _max;
        private float _min;
        private List<SKPoint> pointList = new List<SKPoint>();

        private void Init()
        {
            if (initiated)
            {
                return;
            }

            initiated = true;
              
            foreach (ChartEntry entry in NdviEntires)
            {
                if (entry.Value > _max)
                {
                    _max = entry.Value;
                }
                if (entry.Value < _min)
                {
                    _min = entry.Value;
                }
            }
        }

        public override void DrawContent(SKCanvas canvas, int width, int height)
        {
            Init();

            Entries = NdviEntires;

            var valueLableSizes = MeasureLabels(NdviEntires.Select(x => x.Label).ToArray());
            var footerHeight = CalculateFooterHeaderHeight(valueLableSizes, Orientation.Horizontal);
            var itemSize = CalculateItemSize(width, height, footerHeight, 100);
            var origin = CalculateYOrigin(itemSize.Height, 100);

            var points = base.CalculatePoints(itemSize, origin, 100);
            this.pointList.AddRange(points);

            DrawBars(canvas, points, itemSize, origin, 100);
            DrawBarAreas(canvas, points, itemSize, 100);
            DrawFooter(canvas, NdviEntires.Select(x => x.Label).ToArray(), valueLableSizes, points, itemSize, height, footerHeight);
            DrawLeftLegends(canvas, width, height);
            DrawAverageLine(canvas, width, height);
        }

        private void DrawLeftLegends(SKCanvas canvas, int width, int height)
        {
            var minPoint = pointList.Min(p => p.Y);
            var maxPoint = pointList.Max(p => p.Y);

            var paint = new SKPaint();
            paint.Color = SKColors.Black;
            paint.TextSize = 20;

            canvas.DrawText(_max.ToString(), 0, minPoint - 20, paint);
            canvas.DrawText(_min.ToString(), 0, height - 70, paint);

            var step = maxPoint / 4;
            var valueStep = _max / 4;
            for (int i = 1; i < 4; i++)
            {
                var temp = (maxPoint - step * i);
                if (minPoint < temp && Math.Abs(minPoint - temp) >= step)
                {
                    canvas.DrawText((valueStep * i).ToString(), 0, temp - 20, paint);
                }
            }
        }

        private void DrawAverageLine(SKCanvas canvas, int width, int height)
        {
            int avCount = 1;
            float average = 0;
            foreach (SKPoint p in pointList)
            {
                average += p.Y;
                avCount++;
            }

            average = average / avCount;
            var paint = new SKPaint();
            paint.Color = SKColors.Red;
            paint.StrokeWidth = 5;

            canvas.DrawLine(0, average, width, average, paint);
        }
    }
}
