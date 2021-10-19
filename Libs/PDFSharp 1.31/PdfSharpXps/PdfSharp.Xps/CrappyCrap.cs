using System;
using System.Collections.Generic;
using System.Text;

namespace PdfSharp.Xps
{
    public class CrappyCrap
    {


        public static void AnalyzePath(string path)
        {

            PdfSharp.Xps.Parsing.XpsParser inst = new PdfSharp.Xps.Parsing.XpsParser(null);


            // System.Windows.Media.Geometry geometry = System.Windows.Media.Geometry.Parse(path);
            // XpsModel.PathGeometry pathGeometry = System.Windows.Media.PathGeometry.CreateFromGeometry(geometry);
            XpsModel.PathGeometry pathGeometry = inst.ParsePathGeometry(path);
            

            foreach (XpsModel.PathFigure figure in pathGeometry.Figures)
            {
                // Do something interesting with each path figure.
                foreach (XpsModel.PathSegment segment in figure.Segments)
                {
                    System.Console.WriteLine(segment);
                    string type = segment.GetType().Name;
                    System.Console.WriteLine(type);

                    // Do something interesting with each segment.
                }
            }

        }



        public static void Test()
        {
            // XpsModel.XpsElement mod = PdfSharp.Xps.Parsing.XpsParser.Parse("xml");
            PdfSharp.Xps.Parsing.XpsParser inst = new PdfSharp.Xps.Parsing.XpsParser(null);
            // XpsModel.PathGeometry pg = inst.ParsePathGeometry("M150 0 L75 200 L225 200 Z");
            // XpsModel.PathGeometry pg = inst.ParsePathGeometry("M 200 175 A 25 25 0 0 0 182.322 217.678");
            // XpsModel.PathGeometry pg = inst.ParsePathGeometry("M213.1,6.7c-32.4-14.4-73.7,0-88.1,30.6C110.6,4.9,67.5-9.5,36.9,6.7C2.8,22.9-13.4,62.4,13.5,110.9 C33.3,145.1,67.5,170.3,125,217c59.3-46.7,93.5-71.9,111.5-106.1C263.4,64.2,247.2,22.9,213.1,6.7z");
            XpsModel.PathGeometry pg = inst.ParsePathGeometry("M 25,100 C 25,150 75,150 75,100 S 100,25 150,75");


            System.Console.WriteLine(pg);
        }


    }
}
