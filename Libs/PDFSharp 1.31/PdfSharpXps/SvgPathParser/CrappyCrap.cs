
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
                    string type = segment.GetType().FullName;
                    System.Console.WriteLine(type);

                    // Do something interesting with each segment.
                }
            }

        }


    }
}
