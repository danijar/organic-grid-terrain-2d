using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace OrganicGridTerrain
{
    public partial class fMain : Form
    {
        // settings
        int GridSize = 30;

        public fMain() { InitializeComponent(); }

        // interface
        private void fMain_Load(object sender, EventArgs e) { SlotLoad(); tBGridSize.Value = GridSize; }
        private void btReset_Click(object sender, EventArgs e) { Squares.Clear(); Invalidate(); }
        private void fMain_Resize(object sender, EventArgs e) { Invalidate(); }
        private void btSave_Click(object sender, EventArgs e) { if (MessageBox.Show("Save and Overwrite old Image?", "Organic Grid Terrain", MessageBoxButtons.YesNo) == DialogResult.Yes) SlotSave(); }
        private void btLoad_Click(object sender, EventArgs e) { SlotLoad(); }
        private void tBGridSize_ValueChanged(object sender, EventArgs e) { GridSize = tBGridSize.Value; Invalidate(); }
        private void lGridSize_DoubleClick(object sender, EventArgs e) { tBGridSize.Value = 30; }

        void Repaint(object sender, EventArgs e) { Invalidate(); }
        void SlotSave() { Properties.Settings.Default.Slot = Squares.ToArray(); Properties.Settings.Default.Save(); }
        void SlotLoad() { Squares.Clear(); try { foreach (Point Point in Properties.Settings.Default.Slot) Squares.Add(Point); } catch { } Invalidate(); }

        // vars
        List<Point> Squares = new List<Point>();

        // set blocks
        private void fMain_MouseDown(object sender, MouseEventArgs e)
        {
            Point Mouse = this.PointToClient(MousePosition);
            Point Grid = new Point((int)(Mouse.X / GridSize), (int)(Mouse.Y / GridSize));
            Point Shape = new Point(Grid.X * GridSize, Grid.Y * GridSize);

            if (Squares.Contains(Grid)) Squares.Remove(Grid);
            else Squares.Add(Grid);
            
            Invalidate();
        }

        // paint
        private void fMain_Paint(object sender, PaintEventArgs e)
        {
            // blocks
            Squares.ForEach(Shape => e.Graphics.FillRectangle(Brushes.Black, Shape.X * GridSize, Shape.Y * GridSize, GridSize, GridSize));

            foreach (var Shape in CalcCurves(Squares))
            {
                Matrix Move = new Matrix();
                Move.Translate(Shape.Key.X * GridSize, Shape.Key.Y * GridSize);
                Move.Scale(GridSize, GridSize);
                Move.Multiply(new Matrix(1, 0, 0, -1, 0, 0));
                GraphicsPath Path = Shape.Value;
                Path.Transform(Move);
                e.Graphics.FillPath(Brushes.Gray, Path);
            }

        }

        Dictionary<Point, GraphicsPath> CalcCurves(List<Point> Squares)
        {
            Dictionary<Point, GraphicsPath> Paths = new Dictionary<Point, GraphicsPath>();
            bool DrawTop = cBEdgesTop.Checked;
            bool DrawBottom = cBEdgesBottom.Checked;

            foreach (Point Square in Squares)
            {
                // find top and bottom squares
                bool IsTopSquare = !Squares.Contains(new Point(Square.X, Square.Y - 1));
                bool IsBottomSquare = !Squares.Contains(new Point(Square.X, Square.Y + 1));

                // skip inside squares
                if (!IsTopSquare && !IsBottomSquare) continue;

                // calculate curve
                GraphicsPath Curve = new GraphicsPath();

                List<SideY> Sides = new List<SideY>(); if (IsTopSquare && DrawTop) Sides.Add(SideY.top); if (IsBottomSquare && DrawBottom) Sides.Add(SideY.bottom);
                foreach (SideY Side in Sides)
                {
                    int LeftsOffset = Offset(Square, SideX.left, Side);
                    int RightsOffset = Offset(Square, SideX.right, Side);

                    PointF[] Points = CalcBezier(LeftsOffset, RightsOffset, Side);
                    Curve.AddBezier(Points[0], Points[1], Points[2], Points[3]);
                    Curve.AddLines(new PointF[] { new PointF(1, (Side == SideY.top) ? -1 : 0), new PointF(0, (Side == SideY.top) ? -1 : 0) });
                }

                Paths.Add(Square, Curve);

            }

            return Paths;
        }

        // helper
        PointF[] TwoPoints(float OneX, float OneY, float TwoX, float TwoY) { return new PointF[] { new PointF(OneX, OneY), new PointF(TwoX, TwoY) }; }
        PointF[] ThreePoints(float OneX, float OneY, float TwoX, float TwoY, float ThreeX, float ThreeY) { return new PointF[] { new PointF(OneX, OneY), new PointF(TwoX, TwoY), new PointF(ThreeX, ThreeY) }; }
        PointF[] FourPoints(float OneX, float OneY, float TwoX, float TwoY, float ThreeX, float ThreeY, float FourX, float FourY) { return new PointF[] { new PointF(OneX, OneY), new PointF(TwoX, TwoY), new PointF(ThreeX, ThreeY), new PointF(FourX, FourY) }; }

        enum SideX { left = 0, right = 1 }
        enum SideY { top = 1, bottom = -1 }

        PointF[] CalcBezier(int LeftsOffset, int RightsOffset, SideY SideY)
        {
            PointF[] Points = new PointF[4];

            Points[0] = new PointF(0, LeftsOffset / 2f);
            Points[1] = CalcControlPoint(LeftsOffset, SideX.left);
            Points[2] = CalcControlPoint(RightsOffset, SideX.right);
            Points[3] = new PointF(1, RightsOffset / 2f);

            if (SideY == SideY.bottom)
            {
                for (int i = 0; i < Points.Length; i++) { Points[i].Y *= -1; Points[i].Y -= 1; }
            }

            return Points;
        }

        PointF CalcControlPoint(int Offset, SideX Side)
        {
            PointF Point = new PointF((int)Side, 0);
            if (Math.Abs(Offset) == 1) Point.X = .5f;
            return Point;

            /*
            PointF Point = null;

            if (Offset == 0) return Point;
            else if (Math.Abs(Offset) == 2) Point = new PointF(Side, 0);
            else Point = new PointF(.5f, 0);

            return Point;
            */
        }

        int Offset(Point Base, SideX SideX, SideY SideY) { int OffsetX = (SideX == SideX.left) ? 1 : -1; return SquareOffset(Base, OffsetX, SideY); }

        int SquareOffset(Point Base, int OffsetX, SideY SideY)
        {
            if (IsTranslate(Base, OffsetX, (int)SideY * 1)) { if (IsTranslate(Base, OffsetX, (int)SideY * 2)) return 2; else return 1; }
            else if (IsTranslate(Base, OffsetX, 0)) return 0;
            else if (IsTranslate(Base, OffsetX, (int)SideY * -1)) return -1;
            else if (IsTranslate(Base, 0, (int)SideY * - 1)) return -2;
            else return 0;
        }

        int NeighbourOffsetBottom(Point Base, int OffsetX)
        {
            if (IsTranslate(Base, OffsetX, 1)) { if (IsTranslate(Base, OffsetX, 2)) return 2; else return 1; }
            else if (IsTranslate(Base, OffsetX, 0)) return 0;
            else if (IsTranslate(Base, OffsetX, -1)) return -1;
            else if (IsTranslate(Base, 0, -1)) return -2;
            else return 0;
        }

        bool IsTranslate(Point Base, int OffsetX, int OffsetY) { return Is(new Point(Base.X - OffsetX, Base.Y - OffsetY)); }
        bool Is(Point Base) { return Squares.Contains(Base); }
    }
}
