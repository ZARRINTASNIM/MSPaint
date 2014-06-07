using System;
using System.Drawing;
using System.Windows.Forms;
using Entity;
using BO;

namespace Mpaint
{
    public partial class Form1 : Form
    {
        DrawingEntities v = new DrawingEntities();
        PaintMethods m = new PaintMethods();

        public Form1()
        {
            InitializeComponent();
            pictureBox.Image = new Bitmap(pictureBox.Width, pictureBox.Height);
            v.Imp = pictureBox.Image;
            v.graphichs = Graphics.FromImage(v.Imp);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            v.shouldPaint = false;
            v.AxisLine2 = true;
            v.xAxis2 = (int)e.X;
            v.yAxis2 = (int)e.Y;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                v.shouldPaint = true;
                v.AxisLine1 = true;
                v.AxisLine2 = false;
                v.if_save = true;
                v.xAxis1 = e.X;
                v.yAxis1 = e.Y;
            }
        }

        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (v.drawingBrush && v.shouldPaint)
            {
                v.sbrush = new SolidBrush(Color.FromName(v.colorve));
                v.graphichs.FillEllipse(v.sbrush, e.X, e.Y, 6, 6);
                v.AxisLine1 = false;
            }
            else if (v.shouldPaint && v.drawingPen)
            {
                v.pen = new Pen(Color.FromName(v.colorve));
                v.points.Add(new Point(e.X, e.Y));
                if (v.points.Count > 1)
                {
                    Point[] pointArray = (Point[])v.points.ToArray(v.points[0].GetType());
                    v.graphichs.DrawLines(v.pen, pointArray);
                }
                v.AxisLine1 = false;
            }
            else if (v.shouldPaint && v.drawingEraser)
            {
                v.graphichs.FillEllipse(new SolidBrush(Color.White), e.X, e.Y, 8, 8);
                v.AxisLine1 = false;
            }
            else if (v.drawingLine && v.AxisLine1 && v.AxisLine2)
            {
                m.lineDrawing(v.colorve ,v.graphichs,v.xAxis1, v.yAxis1, v.xAxis2, v.yAxis2);
                v.AxisLine1 = false;
            }
            else if (v.drawingRectangle && v.AxisLine1 && v.AxisLine2)
            {
                m.lineDrawing(v.colorve ,v.graphichs,v.xAxis1, v.yAxis1, v.xAxis2, v.yAxis1);
                m.lineDrawing(v.colorve ,v.graphichs,v.xAxis2, v.yAxis1, v.xAxis2, v.yAxis2);
                m.lineDrawing(v.colorve ,v.graphichs,v.xAxis2, v.yAxis2, v.xAxis1, v.yAxis2);
                m.lineDrawing(v.colorve ,v.graphichs,v.xAxis1, v.yAxis2, v.xAxis1, v.yAxis1);
                v.AxisLine1 = false;
            }
            else if (v.drawingEllipse && v.AxisLine1 && v.AxisLine2)
            {
                m.circleDrawing(v.colorve ,v.graphichs,v.xAxis1,v.yAxis1,v.xAxis2,v.yAxis2);
                v.AxisLine1 = false;
            }

            pictureBox.Image = v.Imp;
        }

        private void Brush_Click(object sender, EventArgs e)
        {
            v.drawingPen = false;
            v.drawingBrush = true;
            v.drawingRectangle = false;
            v.drawingEllipse = false;
            v.drawingLine = false;
            v.drawingEraser = false;
        }

        private void Pencil_Click(object sender, EventArgs e)
        {
            v.drawingRectangle = false;
            v.drawingEllipse = false;
            v.drawingBrush = false;
            v.drawingLine = false;
            v.drawingPen = true;
            v.drawingEraser = false;
        }

        private void Line_Click(object sender, EventArgs e)
        {
            v.drawingRectangle = false;
            v.drawingEllipse = false;
            v.drawingPen = false;
            v.drawingBrush = false;
            v.drawingEraser = false;
            v.drawingLine = true;

        }

        private void Ellipse_Click(object sender, EventArgs e)
        {
            v.drawingRectangle = false;
            v.drawingEllipse = true;
            v.drawingPen = false;
            v.drawingBrush = false;
            v.drawingEraser = false;
            v.drawingLine = false;
        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            v.drawingRectangle = true;
            v.drawingEllipse = false;
            v.drawingPen = false;
            v.drawingBrush = false;
            v.drawingEraser = false;
            v.drawingLine = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            v.drawingRectangle = false;
            v.drawingEllipse = false;
            v.drawingPen = false;
            v.drawingBrush = false;
            v.drawingLine = false;
            v.drawingEraser = true;
        }

        private void Black_Click(object sender, EventArgs e)
        {
            v.colorve = "Black";
        }

        private void DimGray_Click(object sender, EventArgs e)
        {
            v.colorve = "DimGray";
        }

        private void Maroon_Click(object sender, EventArgs e)
        {
            v.colorve = "Maroon";
        }

        private void SaddleBrown_Click(object sender, EventArgs e)
        {
            v.colorve = "SaddleBrown";
        }

        private void Green_Click(object sender, EventArgs e)
        {
            v.colorve = "Green";
        }

        private void Teal_Click(object sender, EventArgs e)
        {
            v.colorve = "Teal";
        }

        private void Navy_Click(object sender, EventArgs e)
        {
            v.colorve = "Navy";
        }

        private void Purple_Click(object sender, EventArgs e)
        {
            v.colorve = "Purple";
        }

        private void DarkOliveGreen_Click(object sender, EventArgs e)
        {
            v.colorve = "DarkOliveGreen";
        }

        private void LightSeaGreen_Click(object sender, EventArgs e)
        {

            v.colorve = "LightSeaGreen";
        }

        private void DarkBlue_Click(object sender, EventArgs e)
        {
            v.colorve = "DarkBlue";
        }

        private void MediumBlue_Click(object sender, EventArgs e)
        {
            v.colorve = "MediumBlue";
        }

        private void MediumSlateBlue_Click(object sender, EventArgs e)
        {
            v.colorve = "MediumSlateBlue";
        }

        private void Brown_Click(object sender, EventArgs e)
        {
            v.colorve = "Brown";
        }

        private void White_Click(object sender, EventArgs e)
        {
            v.colorve = "White";
        }

        private void Silver_Click(object sender, EventArgs e)
        {
            v.colorve = "Silver";
        }

        private void Red_Click(object sender, EventArgs e)
        {
            v.colorve = "Red";
        }

        private void Yellow_Click(object sender, EventArgs e)
        {
            v.colorve = "Yellow";
        }

        private void Lime_Click(object sender, EventArgs e)
        {
            v.colorve = "Lime";
        }

        private void Cyan_Click(object sender, EventArgs e)
        {
            v.colorve = "Cyan";
        }

        private void Blue_Click(object sender, EventArgs e)
        {
            v.colorve = "Blue";
        }

        private void Magenta_Click(object sender, EventArgs e)
        {
            v.colorve = "Magenta";
        }

        

        private void Orange_Click(object sender, EventArgs e)
        {
            v.colorve = "Orange";
        }

        private void SpringGreen_Click(object sender, EventArgs e)
        {
            v.colorve = "SpringGreen";
        }

        private void Aquamarine_Click(object sender, EventArgs e)
        {
            v.colorve = "Aquamarine";
        }

        private void LightSteelBlue_Click(object sender, EventArgs e)
        {
            v.colorve = "LightSteelBlue";
        }

        private void Pink_Click(object sender, EventArgs e)
        {
            v.colorve = "Pink";
        }

        private void Salmon_Click(object sender, EventArgs e)
        {
            v.colorve = "Salmon";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (v.save_as)
            {
                pictureBox.Image.Save(v.savefilename);
            }
            else
            {
                v.saveFile = new SaveFileDialog();
                v.saveFile.Filter = "Bitmap files (*.bmp)|*.bmp|GIF files (*.gif)|*.gif|All files (*.*)|*.*|JPG files (*.jpg)|*.jpg";
                v.saveFile.FilterIndex = 4;
                v.saveFile.RestoreDirectory = true;

                if (v.saveFile.ShowDialog() == DialogResult.OK)
                {
                    v.savefilename = v.saveFile.FileName;
                    pictureBox.Image.Save(v.saveFile.FileName);

                }
                v.save_as = true;
                
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            v.saveFile = new SaveFileDialog();
            v.saveFile.Filter = "Bitmap files (*.bmp)|*.bmp|GIF files (*.gif)|*.gif|All files (*.*)|*.*|JPG files (*.jpg)|*.jpg";
            v.saveFile.FilterIndex = 4;
            v.saveFile.RestoreDirectory = true;

            if (v.saveFile.ShowDialog() == DialogResult.OK)
            {
                v.savefilename = v.saveFile.FileName;
                pictureBox.Image.Save(v.saveFile.FileName);

            }
            v.save_as = true;
        }

        private void editColorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
                v.colorObject = new ColorDialog();
                v.changeColor = v.colorObject.ShowDialog();
                v.pen = new Pen(v.colorObject.Color);
                v.sbrush = new SolidBrush(v.colorObject.Color);
                v.color_change = true; 

            
        }

        private void openCtrlOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string chosen_file;
            OpenFileDialog openFD = new OpenFileDialog();
            openFD.Title = "Open an Image";
            openFD.FileName = "";
            openFD.Filter = "All files (*.*)|*.*|Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|GIF files (*.gif)|*.gif" ;
            if (openFD.ShowDialog() == DialogResult.OK)
            {
                chosen_file = openFD.FileName;
                pictureBox.ImageLocation = chosen_file;
              
        
            }
            else
                return;

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (v.if_save)
            {
                string msg = "Do you want to save it?";
                if (MessageBox.Show(msg, "Paint Brush", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    v.saveFile = new SaveFileDialog();
                    v.saveFile.Filter = "Bitmap files (*.bmp)|*.bmp|GIF files (*.gif)|*.gif|All files (*.*)|*.*|JPG files (*.jpg)|*.jpg";
                    v.saveFile.FilterIndex = 4;
                    v.saveFile.RestoreDirectory = true;

                    if (v.saveFile.ShowDialog() == DialogResult.OK)
                    {
                        v.savefilename = v.saveFile.FileName;
                        pictureBox.Image.Save(v.saveFile.FileName);

                    }
                    v.save_as = true;
                }
            }
            v.graphichs.Clear(pictureBox.BackColor);
        }

     

       

      

       
    }
}
