using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class Frame
    {

        public Frame(float x1, float y1, float x2, float y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
        public float x1
        {
            get;
            set;
        }
        public float y1
        {
            get;
            set;
        }
        public float x2
        {
            get;
            set;
        }
        public float y2
        {
            get;
            set;
        }

        public Frame Clone()
        {
            return new Frame(x1,y1,x2,y2);
        }

        public Frame Add(Frame frame)
        {
            float minx = Math.Min(frame.x1, frame.x2);
            minx = Math.Min(minx, x1);
            minx = Math.Min(minx, x2);
            float miny = Math.Min(frame.y1, frame.y2);
            miny = Math.Min(miny, y1);
            miny = Math.Min(miny, y2);
            float maxx = Math.Max(frame.x1, frame.x2);
            maxx = Math.Max(maxx, x1);
            maxx = Math.Max(maxx, x2);
            float maxy = Math.Max(frame.y1, frame.y2);
            maxy = Math.Max(maxy, y1);
            maxy = Math.Max(maxy, y2);

            x1 = minx;
            x2 = maxx;
            y1 = miny;
            y2 = maxy;
            return frame;
        }
    }
}
