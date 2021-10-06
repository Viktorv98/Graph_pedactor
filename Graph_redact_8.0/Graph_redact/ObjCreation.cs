using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class ObjCreation:BaseState
    {
        Controller controller;
        EditorFasade Edt;
        public ObjCreation(Controller _controller, EditorFasade Edt):base (_controller, Edt)
        {
            controller = _controller;
            this.Edt = Edt;
        }
        public override void MouseDwn(float x, float y)
        {
            Edt.SelectionClear();
            Edt.CreateObject(x, y);
            Containe.i = 4;
            controller.SetState();
        }
    }
}
