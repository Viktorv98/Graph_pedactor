using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    interface IPainterParams
    {
        void SetOutPort(float x1, float y1, float x2, float y2, Graphics graphics);
    }
}
