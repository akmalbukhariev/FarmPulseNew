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
        public List<ChartEntry> NdviEntires = new List<ChartEntry>();
        public List<ChartEntry> YieldEntires = new List<ChartEntry>();

        public string MetricsName = "NDVI";

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

            pointBarList.Clear();
            var pointsBar = base.CalculatePoints(itemSize, origin, 100);
            pointBarList.AddRange(pointsBar);

            DrawBars(canvas, pointsBar, itemSize, origin, 10);

            DrawBarAreas(canvas, pointsBar, itemSize, 100);
            DrawFooter(canvas, NdviEntires.Select(x => x.Label).ToArray(), valueLableSizes, pointsBar, itemSize, height, footerHeight);
            DrawLeftLegends(canvas, width, height);
            //DrawAverageLine(canvas, width, height);

            if (YieldEntires.Count() != 0)
            {
                pointLineList.Clear();
                var pointsLine = CalculateLinePoints(itemSize, origin, 100);

                int index = NdviEntires.FindIndex(item => item.Label.Equals(YieldEntires[0].Label));
                SKPoint barPoint = pointsBar[index];
                float diffX = barPoint.X - pointsLine[0].X;

                pointsLine[0].X = barPoint.X;

                for (int i = 1; i < pointsLine.Length; i++)
                {
                    pointsLine[i].X = pointsLine[i].X + diffX;
                }

                pointLineList.AddRange(pointsLine);
                DrawLines(canvas, width, height);
                //DrawPoints(canvas, pointsLine);
                //DrawBarAreas(canvas, pointsLine, itemSize, origin);
                DrawRightLegends(canvas, width, height);

                //DrawNDVICropYieldLegends(canvas, width, height);
            }
        }

        private void DrawLines(SKCanvas canvas, int width, int height)
        {
            SKPaint paint = new SKPaint();
            var color = string.Format("#{0:X6}", "8FAADC");
            paint.Style = SKPaintStyle.Stroke;
            paint.Color = SKColor.Parse(color);
            paint.StrokeWidth = 7;
            paint.IsAntialias = true;
              
            for (int i = 1; i < pointLineList.Count; i++)
            {
                if (pointLineList.Count > i + 1)
                {
                    canvas.DrawLine(pointLineList[i], pointLineList[i + 1], paint);
                }
                //else
                //{
                //    canvas.DrawLine(pointLineList[i - 1], pointLineList[i], paint);
                //}
            }
        }

        private SKPoint[] CalculateLinePoints(SKSize itemSize, float origin, int headerHeight)
        {
            var result = new List<SKPoint>();

            for (int i = 0; i < YieldEntires.Count(); i++)
            {
                var entry = YieldEntires.ElementAt(i);

                var x = Margin + (itemSize.Width / 2) + (i * (itemSize.Width + Margin));
                var y = headerHeight + ((_lineMax - entry.Value) / (_lineMax - _lineMin) * itemSize.Height);
                var point = new SKPoint(x, y);
                result.Add(point);
            }

            return result.ToArray();
        }

        private void DrawNDVICropYieldLegends(SKCanvas canvas, int width, int height)
        {
            var color1 = String.Format("#{0:X6}", "007A43");
            var color2 = String.Format("#{0:X6}", "8FAADC");
            SKColor barColor = SKColor.Parse(color1);
            SKColor lineColor = SKColor.Parse(color2);

            var barPaint = new SKPaint();
            barPaint.Color = barColor;
            barPaint.TextSize = 30;

            var linePaint = new SKPaint();
            linePaint.Color = lineColor;
            linePaint.TextSize = 30;
            linePaint.StrokeWidth = 8;

            //uz = - 142
            //en = + 20
            //ru = - 134
            //mn = 
            float x1 = width / 2 + 20;

            switch (AppSettings.GetLanguage())
            {
                case Constant.Uzbek: x1 = width / 2 - 142; break;
                case Constant.Russian: x1 = width / 2 - 134; break;
                //case Constant.Mongol: x1 = width / 2 - 142; break;
            }

            canvas.DrawRect(x1, 20, 50, 15, barPaint);
            canvas.DrawText(MetricsName, x1 + 52, 35, barPaint);

            float x2 = x1 + 52 + 80;
            //canvas.DrawRect(x2, 20, 50, 15, linePaint);
            canvas.DrawLine(x2, 25, x2 + 50, 25, linePaint);
            canvas.DrawText(RSC.CropYield, x2 + 52, 35, linePaint);
        }

        private void DrawLeftLegends(SKCanvas canvas, int width, int height)
        {
            var minPoint = pointBarList.Min(p => p.Y);
            var maxPoint = pointBarList.Max(p => p.Y);

            var paint = new SKPaint();
            paint.Color = SKColors.Black;
            paint.TextSize = 20;

            canvas.DrawText(_barMax.ToString("0.00"), 0, minPoint - 20, paint);
            canvas.DrawText(_barMin.ToString("0.00"), 0, height - 70, paint);

            //var step = maxPoint / 4;
            //var valueStep = _barMax / 4;
            //for (int i = 1; i < 4; i++)
            //{
            //    var temp = (maxPoint - step * i);
            //    if (minPoint < temp && Math.Abs(minPoint - temp) >= step)
            //    {
            //        canvas.DrawText((valueStep * i).ToString("0.00"), 0, temp - 20, paint);
            //    }
            //}
        }

        private void DrawRightLegends(SKCanvas canvas, int width, int height)
        {
            var minPoint = pointLineList.Min(p => p.Y);
            var maxPoint = pointLineList.Max(p => p.Y);
            var rightMargin = 40;
            
            var paint = new SKPaint();
            paint.Color = SKColors.Black;
            paint.TextSize = 20;

            canvas.DrawText(_lineMax.ToString("0.00"), width - rightMargin, minPoint - 20, paint);
            canvas.DrawText(_lineMin.ToString("0.00"), width - rightMargin, height - 70, paint);

            //var step = maxPoint / 4;
            //var valueStep = _lineMax / 4;
            //for (int i = 1; i < 4; i++)
            //{
            //    var temp = (maxPoint - step * i);
            //    if (minPoint < temp && Math.Abs(minPoint - temp) >= step)
            //    {
            //        canvas.DrawText((valueStep * i).ToString("0.00"), width - rightMargin, temp - 20, paint);
            //    }
            //}
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
            paint.StrokeWidth = 10;

            canvas.DrawLine(0, average, width, average, paint);
        }
    }
}
