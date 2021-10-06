using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    abstract class GraphItem
    {

        public abstract void Draw(Painter painter);
        public Frame frame;
        public Frame Frame { get { return frame; } }
        public List<Point> point { get; set; }
  
        public bool flag = false;
        public GraphItem(Frame f)
        {
            frame = f;
        }
        public GraphItem()
        {

        }
        public virtual void OffSetGroup(float x, float y)
        {

        }
        public virtual void Sdvig(float x, float y)
        {
            float x1 = frame.x1;
            float y1 = frame.y1;
            float x2 = frame.x2;
            float y2 = frame.y2;
                frame.x2 = x;
                frame.y2 = y;
            
        }
        public virtual void ObratnObmen()
        {
            float x1 = frame.x1;
            float y1 = frame.y1;
            float x2 = frame.x2;
            float y2 = frame.y2;
            frame.x1 = x2;
            frame.y1 = y2;
            frame.x2 = x1;
            frame.y2 = y1;
        }

        public virtual void XObmen()
        {
            float x1 = frame.x1;
            float x2 = frame.x2;
            frame.x1 = x2;
            frame.x2 = x1;
        }

        public virtual void YObmen()
        {
            float y1 = frame.y1;
            float y2 = frame.y2;
            frame.y1 = y2;
            frame.y2 = y1;
        }

        public GraphItem(Frame f, List<Point> p)
        {
            frame = f;
            point = p;
        }
    }
}