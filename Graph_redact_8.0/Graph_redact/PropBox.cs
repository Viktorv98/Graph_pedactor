using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class PropBox:List<Props>
    {
        public void SetParams(Painter p)
        {
           for (int i = 0; i < this.Count; i++)
           {
            this[i].SetParams(p);
           }
        }
    }
}
