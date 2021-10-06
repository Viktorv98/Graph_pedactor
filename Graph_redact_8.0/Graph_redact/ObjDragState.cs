using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class ObjDragState:BaseState
    {
        Controller controller;
        EditorFasade editor;
        public ObjDragState(Controller _controller, EditorFasade _editor):base(_controller, _editor)
        {
            controller = _controller;
            editor = _editor;
        }

        public override void MouseMove(float x, float y, float dx, float dy)
        {
            editor.TryDragSelectionTo(x, y);
        }

        public override void MouseUp(float x, float y)
        {
            Containe.i = 1;
            controller.SetState();
        }

    }
}
