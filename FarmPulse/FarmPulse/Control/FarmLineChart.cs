﻿using Microcharts;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FarmPulse.Control
{
    class FarmLineChart : BarChart
    {
        public IEnumerable<ChartEntry> NdviEntires = new List<ChartEntry>();
        public IEnumerable<ChartEntry> YieldEntires = new List<ChartEntry>();

        private bool initiated = false;
        private float _barMax;
        private float _barMin;
        private float _lineMax;
        private float _lineMin;

        private List<SKPoint> pointBarList = new List<SKPoint>();
        private List<SKPoint> pointLineList = new List<SKPoint>();

        private void Init()
        {
            if (initiated)
            {
                return;
            }

            initiated = true;

            foreach (ChartEntry entry in NdviEntires)
            {
                if (entry.Value > _barMax)
                {
                    _barMax = entry.Value;
                }
                if (entry.Value < _barMin)
                {
                    _barMin = entry.Value;
                }
            }

            foreach (ChartEntry entry in YieldEntires)
            {
                if (entry.Value > _lineMax)
                {
                    _lineMax = entry.Value;
                }
                if (entry.Value < _lineMin)
                {
                    _lineMin = entry.Value;
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

            this.pointBarList.Clear();
            var points = base.CalculatePoints(itemSize, origin, 100);
            this.pointBarList.AddRange(points);

            DrawBars(canvas, points, itemSize, origin, 100);

            DrawBarAreas(canvas, points, itemSize, 100);
            DrawFooter(canvas, NdviEntires.Select(x => x.Label).ToArray(), valueLableSizes, points, itemSize, height, footerHeight);
            DrawLeftLegends(canvas, width, height);
            DrawAverageLine(canvas, width, height);

            if (YieldEntires.Count() != 0)
            {
                this.pointLineList.Clear();
                var points1 = CalculateLinePoints(itemSize, origin, 100);
                this.pointLineList.AddRange(points1);
                DrawLines(canvas, width, height);
                DrawRightLegends(canvas, width, height);
            }
        }

        private void DrawLines(SKCanvas canvas, int width, int height)
        {
            SKPaint paint = new SKPaint();
            paint.Style = SKPaintStyle.Stroke;
            paint.Color = SKColors.Blue;
            paint.StrokeWidth = 5; ;
            paint.IsAntialias = true;

            for (int i = 1; i < pointLineList.Count; i++)
            {
                if (pointLineList.Count > i + 1)
                {
                    canvas.DrawLine(pointLineList[i], pointLineList[i + 1], paint);
                }
            }
        }

        private SKPoint[] CalculateLinePoints(SKSize itemSize, float origin, int headerHeight)
        {
            var result = new List<SKPoint>();

            for (int i = 0; i < this.YieldEntires.Count(); i++)
            {
                var entry = this.YieldEntires.ElementAt(i);

                var x = this.Margin + (itemSize.Width / 2) + (i * (itemSize.Width + this.Margin));
                var y = headerHeight + (((_lineMax - entry.Value) / (_lineMax - _lineMin)) * itemSize.Height);
                var point = new SKPoint(x, y);
                result.Add(point);
            }

            return result.ToArray();
        }

        private void DrawLeftLegends(SKCanvas canvas, int width, int height)
        {
            var minPoint = pointBarList.Min(p => p.Y);
            var maxPoint = pointBarList.Max(p => p.Y);

            var paint = new SKPaint();
            paint.Color = SKColors.Black;
            paint.TextSize = 20;

            canvas.DrawText(_barMax.ToString(), 0, minPoint - 20, paint);
            canvas.DrawText(_barMin.ToString(), 0, maxPoint - 20, paint);

            var step = maxPoint / 4;
            var valueStep = _barMax / 4;
            for (int i = 1; i < 4; i++)
            {
                var temp = (maxPoint - step * i);
                if (minPoint < temp && Math.Abs(minPoint - temp) >= step)
                {
                    canvas.DrawText((valueStep * i).ToString(), 0, temp - 20, paint);
                }
            }
        }

        private void DrawRightLegends(SKCanvas canvas, int width, int height)
        {
            var minPoint = pointLineList.Min(p => p.Y);
            var maxPoint = pointLineList.Max(p => p.Y);

            var paint = new SKPaint();
            paint.Color = SKColors.Black;
            paint.TextSize = 20;

            canvas.DrawText(_lineMax.ToString(), width - 40, minPoint - 20, paint);
            canvas.DrawText(_lineMin.ToString(), width - 40, maxPoint - 20, paint);

            var step = maxPoint / 4;
            var valueStep = _lineMax / 4;
            for (int i = 1; i < 4; i++)
            {
                var temp = (maxPoint - step * i);
                if (minPoint < temp && Math.Abs(minPoint - temp) >= step)
                {
                    canvas.DrawText((valueStep * i).ToString(), width - 40, temp - 20, paint);
                }
            }
        }

        private void DrawAverageLine(SKCanvas canvas, int width, int height)
        {
            int avCount = 1;
            float average = 0;
            foreach (SKPoint p in pointBarList)
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
