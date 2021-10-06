using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class Store : List<GraphItem>
    {
        public Store():base()
        {
           
        }

        //    public void MouseDwn(float x, float y)
        //    {
        //        GraphItem Item = factory.CreateItem();
        //        if (Item == null)
        //            return;
        //        Item.frame.x1 = x;
        //        Item.frame.y1 = y;
        //        Item.frame.x2 = x;
        //        Item.frame.y2 = y;
        //        itemsList.Add(Item);
        //        g = 1;
        //        scena.Paint();
        //    }
        //    public void MouseMove(float x, float y, SelectionList Slist)
        //    {

        //        if (itemsList.Count != 0)

        //        {
        //            scena.Paint();
        //            if (g == 1)
        //            {
        //                GraphItem Item = itemsList[itemsList.Count - 1];
        //Selection sel = new Selection(Item);
        //Slist.Add(sel);
        //float x1 = Item.frame.x1;
        //float y1 = Item.frame.y1;

        //Item.frame.x2 = x;
        //            Item.frame.y2 = y;
    //            }
    //        }
    //    }

    //    public void MouseUp(float x, float y, SelectionList Slist)
    //    {
    //        if (itemsList.Count != 0)
    //        {
    //            g = 0;
    //            Slist.Clear();
    //            scena.Paint();
    //        }
    //    }
    }
}
