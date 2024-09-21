using DoAnPaint.Model;
using DoAnPaint.Utils;
using DoAnPaint.View;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


/*
 * Created by Nguyen Hoang Thinh 17110372 at 19/04/2019
 */
namespace DoAnPaint.Presenter
{
    class PresenterDrawImp : IPresenterDraw
    {
        IViewPaint viewPaint;

        DataManager dataManager;

        public PresenterDrawImp(IViewPaint viewPaint)
        {
            this.viewPaint = viewPaint;
            dataManager = DataManager.getInstance();
        }

        public void OnClickMouseDown(Point p)
        {
            dataManager.IsSave = false;
            dataManager.IsNotNone = true;
            if (dataManager.CurrentShape.Equals(CurrentShapeStatus.Void))
            {
                if (!(Control.ModifierKeys == Keys.Control))
                    dataManager.OffAllShapeSelected();
                viewPaint.RefreshDrawing();
                handleClickToSelect(p);
            }
            else
            {
                handleClickToDraw(p);
            }
        }

        public void handleClickToSelect(Point p)
        {
            for (int i = 0; i < dataManager.ShapeList.Count; ++i)
            {
                if (!(dataManager.ShapeList[i] is MPen))
                    dataManager.PointToResize = dataManager.ShapeList[i].isHitControlsPoint(p);
                if (dataManager.PointToResize != -1)
                {
                    dataManager.ShapeList[i].changePoint(dataManager.PointToResize);
                    dataManager.ShapeToMove = dataManager.ShapeList[i];
                    break;
                }
                else if (dataManager.ShapeList[i].isHit(p))
                {
                    dataManager.ShapeToMove = dataManager.ShapeList[i];
                    dataManager.ShapeList[i].isSelected = true;
                    if (dataManager.ShapeList[i] is MPen)
                    {
                        if (((MPen)dataManager.ShapeList[i]).isEraser)
                        {
                            dataManager.ShapeList[i].isSelected = false;
                            dataManager.ShapeToMove = null;
                        }
                    }
                    break;
                }
            }

            if (dataManager.PointToResize != -1)
            {
                dataManager.CursorCurrent = p;
            }
            else if (dataManager.ShapeToMove != null)
            {
                dataManager.IsMovingShape = true;
                dataManager.CursorCurrent = p;
            }
            else
            {
                dataManager.IsMovingMouse = true;
                dataManager.rectangleRegion = new Rectangle(p, new Size(0, 0));
            }
        }

        private void handleClickToDraw(Point p)
        {
            dataManager.IsMouseDown = true;
            dataManager.OffAllShapeSelected();
            if (dataManager.CurrentShape.Equals(CurrentShapeStatus.Line))
            {
                dataManager.AddEntity(new MLine
                {
                    pointHead = p,
                    pointTail = p,
                    contourWidth = dataManager.LineSize,
                    color = dataManager.ColorCurrent,
                    isFill = dataManager.IsFill
                });
            }
            else if (dataManager.CurrentShape.Equals(CurrentShapeStatus.Rectangle))
            {
                dataManager.AddEntity(new MRectangle
                {
                    pointHead = p,
                    pointTail = p,
                    contourWidth = dataManager.LineSize,
                    color = dataManager.ColorCurrent,
                    isFill = dataManager.IsFill
                });
            }
            else if (dataManager.CurrentShape.Equals(CurrentShapeStatus.Ellipse))
            {
                dataManager.AddEntity(new MEllipse
                {
                    pointHead = p,
                    pointTail = p,
                    contourWidth = dataManager.LineSize,
                    color = dataManager.ColorCurrent,
                    isFill = dataManager.IsFill
                });
            }

            else if (dataManager.CurrentShape.Equals(CurrentShapeStatus.Curve))
            {
                if (!dataManager.IsDrawingCurve)
                {
                    dataManager.IsDrawingCurve = true;
                    MCurve bezier = new MCurve
                    {
                        color = dataManager.ColorCurrent,
                        contourWidth = dataManager.LineSize,
                        isFill = dataManager.IsFill
                    };
                    bezier.points.Add(p);
                    bezier.points.Add(p);
                    dataManager.ShapeList.Add(bezier);
                }
                else
                {
                    MCurve bezier = dataManager.ShapeList[dataManager.ShapeList.Count - 1] as MCurve;
                    bezier.points[bezier.points.Count - 1] = p;
                    bezier.points.Add(p);
                }
                dataManager.IsMouseDown = false;
            }
            else if (dataManager.CurrentShape.Equals(CurrentShapeStatus.Polygon))
            {
                if (!dataManager.IsDrawingPolygon)
                {
                    dataManager.IsDrawingPolygon = true;
                    MPolygon polygon = new MPolygon
                    {
                        color = dataManager.ColorCurrent,
                        contourWidth = dataManager.LineSize,
                        isFill = dataManager.IsFill

                    };
                    polygon.points.Add(p);
                    polygon.points.Add(p);
                    dataManager.ShapeList.Add(polygon);
                }
                else
                {
                    MPolygon polygon = dataManager.ShapeList[dataManager.ShapeList.Count - 1] as MPolygon;
                    polygon.points[polygon.points.Count - 1] = p;
                    polygon.points.Add(p);
                }
                dataManager.IsMouseDown = false;
            }
            else if (dataManager.CurrentShape.Equals(CurrentShapeStatus.Pen))
            {
                dataManager.IsDrawingPen = true;
                MPen pen = new MPen
                {
                    color = dataManager.ColorCurrent,
                    contourWidth = dataManager.LineSize,
                    isFill = dataManager.IsFill
                };
                pen.points.Add(p);
                pen.points.Add(p);
                dataManager.ShapeList.Add(pen);
            }
            else if (dataManager.CurrentShape.Equals(CurrentShapeStatus.Eraser))
            {
                dataManager.IsDrawingEraser = true;
                MPen pen = new MPen
                {
                    color = Color.White,
                    contourWidth = dataManager.LineSize
                };
                pen.isEraser = true;
                pen.points.Add(p);
                pen.points.Add(p);
                dataManager.ShapeList.Add(pen);
            }
        }

        public void GetDrawing(Graphics g)
        {
            throw new System.NotImplementedException();
        }

        public void OnClickMouseMove(Point p)
        {
            throw new System.NotImplementedException();
        }

        public void OnClickMouseUp()
        {
            throw new System.NotImplementedException();
        }

        public void OnClickDrawLine()
        {
            throw new System.NotImplementedException();
        }

        public void OnClickDrawRectangle()
        {
            throw new System.NotImplementedException();
        }

        public void OnClickDrawEllipse()
        {
            throw new System.NotImplementedException();
        }

        public void OnClickDrawBezier()
        {
            throw new System.NotImplementedException();
        }

        public void OnClickDrawPolygon()
        {
            throw new System.NotImplementedException();
        }

        public void OnClickDrawPen()
        {
            throw new System.NotImplementedException();
        }

        public void OnClickDrawEraser()
        {
            throw new System.NotImplementedException();
        }

        public void OnClickStopDrawing(MouseButtons mouse)
        {
            throw new System.NotImplementedException();
        }
    }
}
