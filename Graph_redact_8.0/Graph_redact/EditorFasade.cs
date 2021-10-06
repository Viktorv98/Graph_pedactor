using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_redact
{
    class EditorFasade
    {
        private Painter P;
        private Scena Sc;
        private Factory Fctr;
        private Store store;
        private SelectionList SList;
        private List<GraphItem> list;

        public EditorFasade()
        {
           
            SList = new SelectionList();
            P = new Painter();
            store = new Store();
            Fctr = new Factory();
            Sc = new Scena(P, store, SList);
            Fctr.IType = TypeFigure.None;
            list = new List<GraphItem>();
        }

        public void SetItemType(TypeFigure type)
        {
            Fctr.IType = type;
        }

        public void Repaint()
        {
            Sc.Paint();
        }

        public void Clear()
        {
            store.Clear();
            Sc.Paint();
        }

        public bool CreateObject(float x, float y) //создание объекта
        {
            ClearGroup();
            GraphItem gi = Fctr.CreateItem();
            if (gi == null)
                return false;
            gi.frame.x1 = x;
            gi.frame.y1 = y;
            gi.frame.x2 = x;
            gi.frame.y2 = y;

            store.Add(gi);
            list.Add(gi);
            if (Fctr.IType == TypeFigure.Line)
            {
                Selection sel = new LineSelection(gi);
                SList.Add(sel);
            }
            else
            { 
                Selection sel = new RectSelection(gi);

                SList.Add(sel);
            }
            Sc.Paint();
            return true;
        }

        public bool TrySingleSelect(float x, float y) //попадание в селекшон активной фигуры
        {
            GraphItem gi = store[store.Count - 1];
            gi.flag = true;
            Selection selection = SList[SList.Count - 1];
            bool b = selection.Proverka(gi, x, y);
            Sc.Paint();
            return b;
        }

        public void OffSet(float x, float y)// смещение фигуры
        {
            GraphItem gi = store[store.Count - 1];
            if (gi is Krivaya)
            {
                for (int i = 0; i < gi.point.Count; i++)
                {
                    gi.point[i] = new Point(gi.point[i].X + (int)x, gi.point[i].Y + (int)y);
                }
            }
            if (gi is Group)
            {
                gi.OffSetGroup(x, y);
            }
            gi.frame.x1 += x;
            gi.frame.y1 += y;
            gi.frame.x2 += x;
            gi.frame.y2 += y;
            Sc.Paint();

        }

        public bool CheckArea (float x, float y) //попадание во фрейм фигуры.
        {
            int u = 0;
            for (int k = store.Count - 1; k >= 0; k--)
            {
                GraphItem gi = store[k];
                float minx = Math.Min(gi.frame.x1, gi.frame.x2);
                float maxx = Math.Max(gi.frame.x1, gi.frame.x2);
                float miny = Math.Min(gi.frame.y1, gi.frame.y2);
                float maxy = Math.Max(gi.frame.y1, gi.frame.y2);
                if (x > minx && x < maxx && y > miny && y < maxy)
                {
                    store.RemoveAt(k);
                    store.Add(gi);
                    int k1 = 0;
                    for (int i = 0; i < list.Count; i++)
                        if (gi == list[i])
                            k1++;
                    if (k1 == 0)
                    list.Add(gi);
                    if (gi is Line)
                    {
                        Selection sel = new LineSelection(gi);
                        SList.Add(sel);
                    }
                    else
                    {
                        Selection sel = new RectSelection(gi);

                        SList.Add(sel);
                    }
                    Sc.Paint();
                    u = 1;
                    break;
                }
            }
            if (u == 1) return true;
            else
            {
                list.Clear();
                return false;
            }
        }

        public void SelectionClear()
        {
            ClearGroup();
            SList.Clear();
            Sc.Paint();
        }

        public bool TryDragSelectionTo(float x, float y) //растяжение фигуры
        {
            GraphItem gi = store[store.Count - 1];
            Selection selection = SList[SList.Count - 1];
            gi.Sdvig(x, y);
            Sc.Paint();
            return true;
        }

        public void ClearGroup() // очистка массива выделенных объектов
        {
            list.Clear();
        }
    
        public void AddGroup()// создание группы
        {
            if (list.Count < 2)
            {
                Containe.i = 0;
                return;
            }
            GraphItem gi = Fctr.CreateItem(list);
            if (gi == null)
                return;
            ClearGroup();
            SelectionClear();
            store.Add(gi);
            Selection sel = new RectSelection(gi);
            SList.Add(sel);
            Containe.i = 1;
            Sc.Paint();

        }

        public void UnGroup()// разгруппировка
        {
            if (store.Count < 1)
                return;
            GraphItem gi = store[store.Count - 1];
            if (gi is Group)
            {
                store.RemoveAt(store.Count - 1);
                SelectionClear();
                ClearGroup();
                Sc.Paint();
                Containe.i = 0;
            }
        }

        public bool CreateKrivaya(float x, float y)
        {
            ClearGroup();
            GraphItem gi = Fctr.CreateItem();
            if (gi == null)
                return false;
            gi.frame.x1 = x;
            gi.frame.y1 = y;
            gi.frame.x2 = x;
            gi.frame.y2 = y;
            gi.point.Add(new Point((int)x, (int)y));
            store.Add(gi);
            list.Add(gi);
            Selection sel = new RectSelection(gi);
            SList.Add(sel);
            Sc.Paint();
            return true;
        }

        public void PrintKrivaya(float x, float y)
        {
            GraphItem gi = store[store.Count - 1];
            Selection selection = SList[SList.Count - 1];
            gi.Sdvig(x, y);
            Sc.Paint();
        }

        public void EndCreate()
        {
            GraphItem gi = store[store.Count - 1];
            gi.flag = true;
        }

        public void SetOutPort(Graphics graphics)
        {
            P.SetOutPort(0, 0, 1500, 800, graphics);
        }

    }
}
