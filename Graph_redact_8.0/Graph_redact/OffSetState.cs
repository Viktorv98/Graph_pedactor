using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class OffSetState : BaseState
    {

        Controller controller;
        EditorFasade Edt;
        public OffSetState(Controller _controller, EditorFasade Edt) : base(_controller, Edt)
        {
            controller = _controller;
            this.Edt = Edt;
        }
        public override void MouseMove(float x, float y, float dx, float dy)
        {
            Edt.OffSet(dx, dy);
        }

        public override void MouseUp(float x, float y)
        {
            if (Edt.CheckArea(x, y) == true)
            {
                Containe.i = 1;
            }
            controller.SetState();
        }
    }
}
