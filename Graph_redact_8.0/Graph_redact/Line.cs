using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class Line:AtomGraphItem
    {
        public Line(Frame frame, PropBox box) : base(frame, box)
        {
            this.box = box;
        }
        public override void DrawBody(Painter p)
        {
            p.Line(frame.x1, frame.y1, frame.x2, frame.y2);
        }
    }

    class Rect:AtomGraphItem
    {
        public Rect(Frame frame, PropBox box) : base(frame , box)
        {
            this.box = box;
        }
        public override void DrawBody(Painter p)
        {
            p.Rect(frame.x1, frame.y1, frame.x2, frame.y2);
        }
    }

    class Ellipse : AtomGraphItem
    {
        public Ellipse(Frame frame, PropBox box) : base(frame, box)
        {
            this.box = box;
        }
        public override void DrawBody(Painter p)
        {
            p.Ellipce(frame.x1, frame.y1, frame.x2, frame.y2);
        }
    }
}
