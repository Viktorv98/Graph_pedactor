using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class Controller
    {
        EditorFasade Edt;
        BaseState state = null;
        private BaseState[] states = null;

        public Controller()
        {
            Edt = new EditorFasade();
            states = new BaseState[7];
            states[0] = new Empty(this, Edt);
            states[1] = new SingleSelect(this, Edt);
            states[2] = new MyltiSelect(this,Edt);
            states[3] = new ObjCreation(this, Edt);
            states[4] = new ObjDragState(this, Edt);
            states[5] = new OffSetState(this, Edt);
            states[6] = new KrivayaState(this, Edt);
            state = states[0];

        }
        public void MouseDwn(int x, int y)
        {
                state.MouseDwn(x, y);
        }

        public void MouseUp(int x, int y)
        {
                state.MouseUp(x, y);
        }

        public void MouseMove(float x, float y, float dx, float dy)
        {
            state.MouseMove(x, y,dx,dy);
        }

        public void MouseDwnCtrl(float x, float y)
        {
            state.MouseDwnCtrl(x, y);
        }

        public void Repaint()
        {
            Edt.Repaint();
        }

        public void AddGroup()
        {
            Edt.AddGroup();
            SetState();
        }

        public void SetItemType(TypeFigure type)
        {
            if (type != TypeFigure.None)
                state = states[3];
            if (type == TypeFigure.Graph)
                state = states[6];
            Edt.SetItemType(type);
        }

        public void SetOutPort(Graphics graphics)
        {
            Edt.SetOutPort(graphics);
        }

        public void SetState ()
        {
            state = states[Containe.i];
        }

        public void UnGroup()
        {
            Edt.UnGroup();
            SetState();
        }
    }
}