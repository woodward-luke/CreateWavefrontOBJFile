using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateWavefrontObjFile.Legoman
{
    class Leg: IObj
    {
        private int density = 50;
		    
        public List<double[]> vertices { get; set; }
        public List<int[]> faces { get; set; }
        public string objModelName { get; set; }
        public void initialiseVerticies()
        {
            vertices = new List<double[]>();
            vertices.Add(new Double[] { 3.585, 0, 3.935 });
            vertices.Add(new Double[] { -3.585, 0, 3.935 });
            vertices.Add(new Double[] { 3.585, 0, -3.935 });
            vertices.Add(new Double[] { -3.585, 0, -3.935 });
            vertices.Add(new Double[] { 3.585, 3.17, -3.935 });
            vertices.Add(new Double[] { -3.585, 3.17, -3.935 });
            vertices.Add(new Double[] { 3.585, 3.17, -1.663 });
            vertices.Add(new Double[] { -3.585, 3.17, -1.663 });


            double z1 = 0;
            double y1 = 11.06f;
            double thetaStep = 234.445159f / density;
            double theta = 234.445159f;

            double z;
            double y;

            for (int i = 0; i < (density + 1); i++)
            {
                z = Math.Cos(Math.PI * theta / 180.0) * 3.54;
                y = Math.Sin(Math.PI * theta / 180.0) * 3.54;

                vertices.Add(new Double[] { 3.585, y1 + y, z1 + z });
                vertices.Add(new Double[] { -3.585, y1 + y, z1 + z });

                theta = theta - thetaStep;
            }

            vertices.Add(new Double[] { 3.585, y1, z1 });
            vertices.Add(new Double[] { -3.585, y1, z1 });
        }
        public void initialiseFaces()
        {
            faces = new List<int[]>();
            // now set up the faces - note that the vertex order is always
            // specified counter-clockwise when that face is viewed front on

            for (int i = 0; i < (4 + density) * 2; i = i + 2)
            {
                faces.Add(new int[] { i + 3 + 1, i + 2 + 1, i + 1, i + 1 + 1 });
            }

            for (int i = 0; i < density; i++)
            {
                faces.Add(new int[] { vertices.Count - 1 + 1, 11 + 2 * i + 1, 9 + 2 * i + 1 });
                faces.Add(new int[] { vertices.Count - 2 + 1, 8 + 2 * i + 1, 10 + 2 * i + 1 });
            }

            faces.Add(new int[] { 2 + 1, 4 + 1, 6 + 1, 0 + 1 });
            faces.Add(new int[] { 6 + 1, 8 + 1, vertices.Count - 4 + 1, 0 + 1 });
            faces.Add(new int[] { 8 + 1, vertices.Count - 2 + 1, vertices.Count - 4 + 1 });

            faces.Add(new int[] { 0 + 1, vertices.Count - 4 + 1, vertices.Count - 3 + 1, 1 + 1 });

            faces.Add(new int[] { 1 + 1, 7 + 1, 5 + 1, 3 + 1 });
            faces.Add(new int[] { 1 + 1, vertices.Count - 3 + 1, 9 + 1, 7 + 1 });
            faces.Add(new int[] { vertices.Count - 3 + 1, vertices.Count - 1 + 1, 9 + 1 });
		    


        }
        public void initialiseModelName()
        {
            objModelName = "Leg";
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
