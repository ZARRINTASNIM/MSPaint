using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Entity
{
  public class DrawingEntities
    {

       public bool shouldPaint = false;
       public bool drawingBrush = true;
       public bool drawingPen = false;
       public bool drawingEraser = false;
       public bool drawingEllipse = false;
       public bool drawingRectangle = false;
       public bool drawingLine = false;
       public bool AxisLine1 = false;
       public bool AxisLine2 = false;
       public bool color_change = false;
       public bool if_save = false;
       public bool save_as = false;
       public Image Imp;
       public DialogResult changeColor;
       public ColorDialog colorObject;
       public Graphics graphichs;
       public Pen pen = new Pen(Color.Black);
       public SolidBrush sbrush = new SolidBrush(Color.Black);
       public String savefilename;
       public SaveFileDialog saveFile;
       public int xAxis1, yAxis1, xAxis2, yAxis2;
       public ArrayList points = new ArrayList();
       public String colorve = "Black";



    }
}
