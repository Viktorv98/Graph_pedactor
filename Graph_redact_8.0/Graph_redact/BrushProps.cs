using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class BrushProps:Props
    {
        public BrushProps (Color c)
        {
            Color = c;
        }
        public Color Color
        {
            get;
            set;
        }

        public override void SetParams(Painter p)
        {
            p.brushColor = Color;
        }
    }
}
