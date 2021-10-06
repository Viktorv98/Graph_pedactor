using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class Group:GraphItem
    {
        public List<GraphItem> list = new List<GraphItem>();
        public List<Frame> Plist = new List<Frame>();
        public Group(List<GraphItem> list):base(null)
        {
            for (int i = 0; i < list.Count; i++)
            this.list.Add(list[i]);
            frame = this.list[0].frame.Clone();
            for (int i = 1; i < this.list.Count; i++)
                frame.Add(list[i].Frame);
            float x1 = frame.x1;
            float y1 = frame.y1;
            float x2 = frame.x2;
            float y2 = frame.y2;
            float delx = (x2 - x1);
            float dely = (y2 - y1);
            for (int i = 0; i < this.list.Count; i++)
                Plist.Add(new Frame((list[i].frame.x1 - x1) / delx, (list[i].frame.y1 - y1) / dely, (list[i].frame.x2 - x1) / delx, (list[i].frame.y2 - y1) / dely));
        }

        public override void OffSetGroup(float x, float y)
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                if (list[i] is Group)
                    list[i].OffSetGroup(x, y);
                if (list[i] is Krivaya)
                {
                    for (int j = 0; j < list[i].point.Count; j++)
                    {
                        list[i].point[j] = new Point(list[i].point[j].X + (int)x, list[i].point[j].Y + (int)y);
                    }
                }
                this.list[i].frame.x1 += x;
                this.list[i].frame.y1 += y;
                this.list[i].frame.x2 += x;
                this.list[i].frame.y2 += y;
            }
        }

        public override void Sdvig(float x, float y)
        {

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is Group)
                     list[i].Sdvig(frame.x1 + Plist[i].x2 * (x - frame.x1),frame.y1 + Plist[i].y2 * (y - frame.y1));
                if (list[i] is Krivaya)
                    list[i].Sdvig(frame.x1 + Plist[i].x2 * (x - frame.x1), frame.y1 + Plist[i].y2 * (y - frame.y1));
                list[i].frame.x1 = frame.x1 + Plist[i].x1*(x-frame.x1);
                list[i].frame.x2 = frame.x1 + Plist[i].x2*(x-frame.x1);
                list[i].frame.y1 = frame.y1 + Plist[i].y1*(y-frame.y1);
                list[i].frame.y2 = frame.y1 + Plist[i].y2*(y-frame.y1);
            }
            frame.x2 = x;
            frame.y2 = y;
        }

        public override void ObratnObmen()
        {
            float x1 = frame.x1;
            float y1 = frame.y1;
            float x2 = frame.x2;
            float y2 = frame.y2;
            for (int i = 0; i < list.Count; i++)
            {
                Plist[i].x1 = 1 - Plist[i].x1;
                Plist[i].x2 = 1 - Plist[i].x2;
                Plist[i].y1 = 1 - Plist[i].y1;
                Plist[i].y2 = 1 - Plist[i].y2;
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
            for (int i = 0; i < list.Count; i++)
            {
                Plist[i].x1 = 1 - Plist[i].x1;
                Plist[i].x2 = 1 - Plist[i].x2;
            }
            frame.x1 = x2;
            frame.x2 = x1;
        }

        public override void YObmen()
        {
            float y1 = frame.y1;
            float y2 = frame.y2;
            for (int i = 0; i < list.Count; i++)
            {
                Plist[i].y1 = 1 - Plist[i].y1;
                Plist[i].y2 = 1 - Plist[i].y2;
            }
            frame.y1 = y2;
            frame.y2 = y1;
        }

        public override void Draw(Painter paint)
        {
            for (int i = 0; i < this.list.Count; i++)
            {
                this.list[i].Draw(paint);
            }
        }
    }
}
