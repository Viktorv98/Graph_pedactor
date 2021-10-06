using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    abstract class AtomGraphItem:GraphItem
    {

        public PropBox box;
        
        protected AtomGraphItem(Frame frame,PropBox box) : base(frame)
        {
            this.box = box;
        }

        public override void Draw(Painter paint)
        {
            box.SetParams(paint);
            DrawBody(paint);
        }
        public abstract void DrawBody(Painter p);
    }
}
