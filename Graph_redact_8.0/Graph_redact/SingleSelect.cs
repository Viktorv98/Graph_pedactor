using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class SingleSelect:BaseState
    {
        Controller controller;
        EditorFasade Edt;
        public SingleSelect(Controller _controller, EditorFasade Edt) : base(_controller, Edt)
        {
            controller = _controller;
            this.Edt = Edt;
        }
        public override void MouseDwn(float x, float y)
        {
            if (Edt.TrySingleSelect(x, y) == true)
            {
                Containe.i = 4;
                controller.SetState();
            }
            else
            {
                Edt.SelectionClear();
                Edt.ClearGroup();
                if (Edt.CheckArea(x, y) == true)
                {
                    Containe.i = 5;
                    controller.SetState();
                }
                else
                {;
                    Edt.SelectionClear();
                    Containe.i = 0;
                    controller.SetState();
                }
            }
        }
        public override void MouseDwnCtrl(float x, float y)
        {
            if (Edt.CheckArea(x,y) == true)
            {
                Containe.i = 2;
                controller.SetState();
            }
            else
            {
                Containe.i = 0;
                controller.SetState();
            }
        }
    }
}
