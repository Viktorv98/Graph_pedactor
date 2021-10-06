using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    abstract class Props
    {
        public abstract void SetParams(Painter p);
    }

    class PenProps:Props
    {
        public override void SetParams(Painter p)
        {
            p.penColor = Color;
            p.penWidth = Width;
        }

        public Color Color
        {
            get;
            set;
        }

        private int Width
        {
            get;
            set;
        }

        public PenProps(Color c, int w)
        {
            Color = c;
            Width = w;
        }
    }

    
}
