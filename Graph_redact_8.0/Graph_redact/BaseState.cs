using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    abstract class BaseState
    {
        Controller controller;
        EditorFasade editor;
        public BaseState (Controller _controller, EditorFasade _editor)
        {
            controller = _controller;
            editor = _editor;
        }
        public virtual void MouseDwn(float x, float y)
        { }
        public virtual void MouseUp(float x, float y)
        { }
        public virtual void MouseMove(float x, float y, float dx, float dy)
        { }
        public virtual void MouseDwnCtrl(float x, float y)
        { }
    }

    static class Containe
    {
        public static int i = 0;
    }
}
