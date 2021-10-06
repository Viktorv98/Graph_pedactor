using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class Scena
    {
        Painter pn;
        Store list;
        SelectionList Slist;

        public Scena(Painter Pn, Store List, SelectionList selection)
        {
            pn = Pn;
            list = List;
            Slist = selection;
        }

        public void Paint()
        {
            pn.BeginPaint();
            for (int i = 0; i < list.Count; i++)
                    list[i].Draw(pn);

            for (int i = 0; i < Slist.Count; i++)
                Slist[i].Draw(pn);

            pn.EndPaint();
        }
    }
}
