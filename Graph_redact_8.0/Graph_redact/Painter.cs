using System.Drawing;
using System;
using System.Collections.Generic;

namespace Graph_redact
{
    class Painter:IPainterParams
    {
        private Graphics g;
        private Graphics gOut;

        Bitmap BM;
        Pen P = new Pen(Color.Black, 2);
        SolidBrush S = new SolidBrush(Color.Aqua);


        public Color penColor
        {
            set { P.Color = value; }
        }

        public int penWidth
        {
            set { P.Width = value; }
        }

        public Color brushColor
        {
            set { S.Color = value; }
        }

        public Painter (Graphics g)
        {
            this.g = g;

        }

        public Painter()
        {
            g = null;
        }

        public void BeginPaint()
        {
            g.Clear(Color.White);
        }

        public void EndPaint()
        {
            gOut.DrawImage(BM, 0, 0);
        }

        public void Line (float x1, float y1, float x2, float y2)
        {
            g.DrawLine(P, x1, y1, x2, y2);
        }

        public void Rect(float x1, float y1, float x2, float y2)
        {
            float minx, miny;
            if (x1 < x2)
                minx = x1;
            else
                minx = x2;
            if (y1 < y2)
                miny = y1;
            else
                miny = y2;
            g.FillRectangle(S, minx, miny, Math.Abs(x2 - x1), Math.Abs(y2 - y1));
            g.DrawRectangle(P, minx, miny, Math.Abs(x2 - x1), Math.Abs(y2 - y1));
             
        }

        public void Ellipce(float x1, float y1, float x2, float y2)
        {
            SolidBrush s = new SolidBrush(Color.Aqua);
            g.FillEllipse(s, x1, y1, x2 - x1, y2 - y1);
            s.Dispose();
            g.DrawEllipse(P, x1, y1, x2 - x1, y2 - y1);
        }

        public void Krivaya(List<Point> point)
        {
            g.DrawBeziers(P, point.ToArray());
        }

        public void SetOutPort(float x1, float y1, float x2, float y2, Graphics graphics)
        {
            gOut = graphics;
            BM = new Bitmap(Convert.ToInt32(Math.Abs(x2 - x1)), Convert.ToInt32(Math.Abs(y2 - y1)));
            g = Graphics.FromImage(BM);
        }
    }
}