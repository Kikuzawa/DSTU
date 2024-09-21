using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

using System.Windows.Forms;
using System.Windows.Shapes;

namespace DoAnPaint
{
    public partial class PaintView : Form
    {
        private List<Shape> shapes = new List<Shape>();
        private Graphics g;

        public PaintView()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Включаем двойное буферирование для лучшей производительности

        }
        private void PaintView_Load(object sender, System.EventArgs e)
        { 
            g = this.CreateGraphics();


            

        }
        


        private void DrawCircle(int x, int y, int radius, Color penColor, Color brushColor)
        {
            Pen pen = new Pen(penColor, 2);
            SolidBrush brush = new SolidBrush(brushColor);
            g.DrawEllipse(pen, x, y, radius * 2, radius * 2);
            g.FillEllipse(brush, x, y, radius * 2, radius * 2);
        }

        private void DrawRectangle(int x, int y, int width, int height, Color penColor, Color brushColor)
        {
            Pen pen = new Pen(penColor, 2);
            SolidBrush brush = new SolidBrush(brushColor);
            g.DrawRectangle(pen, x, y, width, height);
            g.FillRectangle(brush, x, y, width, height);
        }

        private void DrawTriangle(int x, int y, int size, Color color)
        {
            Pen pen = new Pen(color, 2);
            g.DrawLine(pen, x, y, x + size, y);
            g.DrawLine(pen, x, y, x, y + size);
            g.DrawLine(pen, x + size, y, x, y + size);
        }

        private void DrawLine(int x1, int y1, int x2, int y2, Color color, int thickness)
        {
            Pen pen = new Pen(color, thickness);
            g.DrawLine(pen, x1, y1, x2, y2);
        }

        private void drawButton_Click(object sender, System.EventArgs e)
        {
            pictureBox.Hide();
            Graphics g = this.CreateGraphics();
            Pen a = new Pen(Color.Red, 6);
            Pen b = new Pen(Color.Green, 6);

            SolidBrush myBrush = new SolidBrush(Color.Blue);

            g.DrawRectangle(a, 800, 400, 50, 100);
            
            g.DrawEllipse(b, 300, 370, 400, 200);
            g.FillEllipse(myBrush, 300, 370, 400, 200);
            DrawCircle(100, 100, 100, Color.Red, Color.White);
            DrawRectangle(50, 50, 30, 40, Color.Blue, Color.Gray);
            DrawTriangle(450, 100, 250, Color.Green);
            DrawLine(150, 350, 250, 450, Color.Black, 3);

        }

        private void saveButton_Click(object sender, System.EventArgs e)

        {
            ImageFormat img = ImageFormat.Jpeg;
            saveFile.ShowDialog();
            System.Drawing.Rectangle bounds = this.Bounds;

            Bitmap bitmap = new Bitmap(bounds.Width - 200, bounds.Height - 100);
            Graphics g = Graphics.FromImage(bitmap);
            g.CopyFromScreen(new Point(370, 210), Point.Empty, bounds.Size);
            bitmap.Save(saveFile.FileName, img);
           
        }

        private void loadButton_Click(object sender, System.EventArgs e)
        {
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                Bitmap image = new Bitmap(openFile.FileName);
                pictureBox.Image = image;
            }

        }

      


    }

    

    
}



