using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateWavefrontObjFile.Legoman
{
    class Wrist: IObj
    {
        private int density = 200;
		private double radius = 0.7;
        private double length = 2;
        public List<double[]> vertices { get; set; }
        public List<int[]> faces { get; set; }
        public string objModelName { get; set; }
        public void initialiseVerticies()
        {
            vertices = new List<double[]>();
            
            double x;
            double y;
            double yRot;

            vertices.Add(new double[] { 0, 0, 0 });
            vertices.Add(new double[] { 0, 0, length });

            for (int j = 0; j < density; j++)
            {
                // calculate angle around Y axis
                yRot = j * (360.0 / density);

                // calculate x, y & z coordinates
                x = cos_d(yRot) * radius;
                y = sin_d(yRot) * radius;

                vertices.Add(new double[]{x, y, 0});
                vertices.Add(new double[]{x, y, length});
            }
        }
        public void initialiseFaces()
        {
            faces = new List<int[]>();
            // now set up the faces - note that the vertex order is always
            // specified counter-clockwise when that face is viewed front on

            for (int i = 0; i < density*2-2; i=i+2)
            {
                faces.Add(new int[]{1, i+3, i+5});
                faces.Add(new int[] { 2, i+6, i+4 });
                faces.Add(new int[]{i+3, i+4, i+6, i+5});
            }

            faces.Add(new int[] { 1, (vertices.Count - 1), 3 });
            faces.Add(new int[] { 2, 4, (vertices.Count) });
            faces.Add(new int[] { vertices.Count - 1, vertices.Count, 4, 3 });
        }
        public void initialiseModelName()
        {
            objModelName = "Wrist";
        }
        public double cos_d(double angle_degrees)
        {
            return Math.Cos(Math.PI * angle_degrees / 180.0);
        }
        public double sin_d(double angle_degrees)
        {
            return Math.Sin(Math.PI * angle_degrees / 180.0);
        }
    }
}
