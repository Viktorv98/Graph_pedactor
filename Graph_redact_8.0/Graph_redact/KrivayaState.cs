namespace Graph_redact
{
    internal class KrivayaState : BaseState
    {
        private int i = 0;
        Controller controller;
        EditorFasade Edt;
        public KrivayaState(Controller _controller, EditorFasade Edt) : base(_controller, Edt)
        {
            controller = _controller;
            this.Edt = Edt;
        }

        public override void MouseDwn(float x, float y)
        {
            Edt.SelectionClear();
            Edt.CreateKrivaya(x, y);
            i = 1;
        }

        public override void MouseMove(float x, float y, float dx, float dy)
        {
            if (i != 0)
            Edt.PrintKrivaya(x, y); 
        }

        public override void MouseUp(float x, float y)
        {
            i = 0;
            Edt.EndCreate();
            Containe.i = 1;
            controller.SetState();
        }

    }
}