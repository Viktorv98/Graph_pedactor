using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    public enum TypeFigure {None, Line, Rect, Ellipse, Group, Graph};

    class Factory
    {
        private PenProps PP;
        private BrushProps BP;

        public Factory()
        {

        }

        public TypeFigure IType { set; get; }

        public GraphItem CreateItem(List<GraphItem> list)
        {

            return new Group(list);
        }

            public GraphItem CreateItem()
        {
            switch (IType)
            {
                case TypeFigure.Line:
                    {
                        PropBox pb = new PropBox();
                        PenProps pp = new PenProps(Color.Black, 2);
                        pb.Add(pp);
                        Frame frame = new Frame(0, 0, 0, 0);
                        return new Line(frame, pb);
                    }
                case TypeFigure.Rect:
                    {
                        PropBox prop = new PropBox();
                        PenProps pp = new PenProps(Color.Black, 2);
                        BrushProps bp = new BrushProps(Color.Aqua);
                        prop.Add(pp);
                        prop.Add(bp);
                        Frame frame = new Frame(0, 0, 0, 0);
                        return new Rect(frame, prop);
                    }
                case TypeFigure.Ellipse:
                    {
                        PropBox prop = new PropBox();
                        PenProps pp = new PenProps(Color.Black, 2);
                        BrushProps bp = new BrushProps(Color.Aqua);
                        prop.Add(pp);
                        prop.Add(bp);
                        Frame frame = new Frame(0, 0, 0, 0);
                        return new Ellipse(frame, prop);
                    }
                case TypeFigure.Graph:
                    {
                        PropBox prop = new PropBox();
                        PenProps pp = new PenProps(Color.Black, 2);
                        BrushProps bp = new BrushProps(Color.Aqua);
                        prop.Add(pp);
                        prop.Add(bp);
                        Frame frame = new Frame(0, 0, 0, 0);
                        List<Point> point = new List<Point>();
                        return new Krivaya(frame, point, prop);
                    }
                case TypeFigure.Group:
                    {
                        List<GraphItem> list = new List<GraphItem>();

                        return new Group(list);
                    }
                default:
                    return null;
            }
        }       
    }
}
