using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class Selection
    {
        GraphItem Item;

        public Selection(GraphItem item)
        {
            Item = item;
        }

        virtual public bool Proverka (GraphItem gi, float x, float y)
        {
            float x1 = gi.frame.x1;
            float y1 = gi.frame.y1;
            float x2 = gi.frame.x2;
            float y2 = gi.frame.y2;
            if (x > x2 - 5 && x < x2 + 5 && y > y2 - 5 && y < y2 + 5)
            {
                return true;
            }
            else
           if (x > x1 - 5 && x < x1 + 5 && y > y1 - 5 && y < y1 + 5)
            {
                gi.ObratnObmen();
                return true;
            }
            else
           if (x > x1 - 5 && x < x1 + 5 && y > y2 - 5 && y < y2 + 5)
            {
                gi.XObmen();
                return true;
            }
            else
           if (x > x2 - 5 && x < x2 + 5 && y > y1 - 5 && y < y1 + 5)
            {
                gi.YObmen();
                return true;
            }
            else
                return false;
        }

        virtual public void Draw(Painter Pn)
        {
            float x1 = Item.frame.x1;
            float x2 = Item.frame.x2;
            float y1 = Item.frame.y1;
            float y2 = Item.frame.y2;
            Pn.Rect(x1 - 3, y1 - 3, x1 + 3, y1 + 3);
            Pn.Rect(x2 - 3, y2 - 3, x2 + 3, y2 + 3);
            Pn.Rect(x1 - 3, y2 - 3, x1 + 3, y2 + 3);
            Pn.Rect(x2 - 3, y1 - 3, x2 + 3, y1 + 3);
        }
    }

    class LineSelection:Selection 
    {
        GraphItem Item;

        public LineSelection(GraphItem item):base(item)
        {
            Item = item;
        }

        override public void Draw(Painter Pn)
        {
            float x1 = Item.frame.x1;
            float x2 = Item.frame.x2;
            float y1 = Item.frame.y1;
            float y2 = Item.frame.y2;
            Pn.Rect(x1 - 3, y1 - 3, x1 + 3, y1 + 3);
            Pn.Rect(x2 - 3, y2 - 3, x2 + 3, y2 + 3);
        }
        public override bool Proverka(GraphItem gi, float x, float y)
        {
            float x1 = gi.frame.x1;
            float y1 = gi.frame.y1;
            float x2 = gi.frame.x2;
            float y2 = gi.frame.y2;
            if (x > x2 - 5 && x < x2 + 5 && y > y2 - 5 && y < y2 + 5)
            {
                return true;
            }
            else
           if (x > x1 - 5 && x < x1 + 5 && y > y1 - 5 && y < y1 + 5)
            {
                gi.frame.x1 = x2;
                gi.frame.y1 = y2;
                gi.frame.x2 = x1;
                gi.frame.y2 = y1;
                return true;
            }
            else
                return false;
        }
    }

    class RectSelection : Selection
    {
        GraphItem Item;

        public RectSelection(GraphItem item):base (item)
        {
            Item = item;
        }
    }

        class SelectionList : List<Selection>
    {

    }
}
