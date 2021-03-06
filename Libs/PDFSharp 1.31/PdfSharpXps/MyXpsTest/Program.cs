using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyXpsTest
{
    class Program
    {

        public static void AnalyzePath(string path)
        {
            System.Windows.Media.Geometry geometry = System.Windows.Media.Geometry.Parse(path);

            System.Windows.Media.PathGeometry pathGeometry = System.Windows.Media.PathGeometry.CreateFromGeometry(geometry);
            System.Console.WriteLine(pathGeometry);

            foreach (System.Windows.Media.PathFigure figure in pathGeometry.Figures)
            {
                // Do something interesting with each path figure.
                foreach (System.Windows.Media.PathSegment segment in figure.Segments)
                {
                    System.Console.WriteLine(segment);
                    string type = segment.GetType().Name;
                    System.Console.WriteLine(type);

                    // Do something interesting with each segment.
                }
            }

        }


        // https://stackoverflow.com/questions/5115388/parsing-svg-path-elements-with-c-sharp-are-there-libraries-out-there-to-do-t
        static void Main(string[] args)
        {
            // PdfSharp.Xps.CrappyCrap.Test();
            

            string[] paths = new string[] {
                "M150 0 L75 200 L225 200 Z"
                ,"M 200 175 A 25 25 0 0 0 182.322 217.678"
                ,"M213.1,6.7c-32.4-14.4-73.7,0-88.1,30.6C110.6,4.9,67.5-9.5,36.9,6.7C2.8,22.9-13.4,62.4,13.5,110.9 C33.3,145.1,67.5,170.3,125,217c59.3-46.7,93.5-71.9,111.5-106.1C263.4,64.2,247.2,22.9,213.1,6.7z"
                // ,"M 25,100 C 25,150 75,150 75,100 S 100,25 150,75"
                //,"M5.4,3.806h6.336v43.276h20.738v5.256H5.4V3.806z"
            };

            string selectedPath = paths[paths.Length - 1];

            AnalyzePath(selectedPath);
            System.Console.WriteLine(" ==================================== ");
            PdfSharp.Xps.CrappyCrap.AnalyzePath(selectedPath);

            System.Console.WriteLine(" --- Press any key to continue --- ");
            System.Console.ReadKey();
        }
    }
}
