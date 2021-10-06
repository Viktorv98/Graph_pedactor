using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class Empty:BaseState
    {
        Controller controller;
        EditorFasade editor;
        public Empty(Controller _controller, EditorFasade _editor):base (_controller, _editor)
        {
            controller = _controller;
            editor = _editor;
        }
        public override void MouseUp(float x, float y)
        {
            if (editor.CheckArea(x, y) == true)
            {
                Containe.i = 1;
            }
            controller.SetState();
        }
    }
}
