using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class Krivaya : GraphItem
    {
        public PropBox box;
        private int p = 0;
        public List<PointF> Plist = new List<PointF>();
        public Krivaya(Frame frame, List<Point> point, PropBox box) : base(frame, point)
        {
            this.point = point;
            this.box = box;
        }
        public override void Draw(Painter p)
        {
            box.SetParams(p);
            p.Krivaya(point);
        }

        public void End()
        {
            float x1 = frame.x1;
            float y1 = frame.y1;
            float x2 = frame.x2;
            float y2 = frame.y2;
            float delx = (x2 - x1);
            float dely = (y2 - y1);
            for (int i = 0; i < this.point.Count; i++)
                this.Plist.Add(new PointF((point[i].X - x1) / delx, (point[i].Y - y1) / dely));
            p = 1;
        }

        public override void Sdvig(float x, float y)
        {
            float x1 = frame.x1;
            float y1 = frame.y1;
            float x2 = frame.x2;
            float y2 = frame.y2;
            if (flag == false)
            {

                float minx = Math.Min(x1, x2), miny = Math.Min(y1, y2), maxx = Math.Max(x1, x2), maxy = Math.Max(y1, y2);
                point.Add(new Point((int)x, (int)y));
                point.Add(new Point((int)x, (int)y));
                point.Add(new Point((int)x, (int)y));
                if (x < minx) { minx = x; }
                if (x > maxx) { maxx = x; }
                if (y < miny) { miny = y; }
                if (y > maxy) { maxy = y; }
                frame.x1 = minx;
                frame.y1 = miny;
                frame.x2 = maxx;
                frame.y2 = maxy;
            }
            else
            {
                if (p == 0)
                    End();
                for (int i = 0; i < point.Count; i++)
                {
                    point[i] = new Point((int)(frame.x1 + Plist[i].X*(x - x1)), (int)(frame.y1 + Plist[i].Y*(y-y1)));
                }
                frame.x2 = x;
                frame.y2 = y;
            }
        }

        public override void ObratnObmen()
        {
            float x1 = frame.x1;
            float y1 = frame.y1;
            float x2 = frame.x2;
            float y2 = frame.y2;
            for (int i = 0; i < Plist.Count; i++)
            {
                Plist[i] = (new PointF(1 - Plist[i].X,1 - Plist[i].Y));
            }
            frame.x1 = x2;
            frame.y1 = y2;
            frame.x2 = x1;
            frame.y2 = y1;

        }

        public override void XObmen()
        {
            float x1 = frame.x1;
            float x2 = frame.x2;
            for (int i = 0; i < Plist.Count; i++)
            {
                Plist[i] = (new PointF(1 - Plist[i].X,Plist[i].Y));
            }
            frame.x1 = x2;
            frame.x2 = x1;
        }

        public override void YObmen()
        {
            float y1 = frame.y1;
            float y2 = frame.y2;
            for (int i = 0; i < Plist.Count; i++)
            {
                Plist[i] = (new PointF(Plist[i].X, 1 - Plist[i].Y));
            }
            frame.y1 = y2;
            frame.y2 = y1;
        }
    }
}
