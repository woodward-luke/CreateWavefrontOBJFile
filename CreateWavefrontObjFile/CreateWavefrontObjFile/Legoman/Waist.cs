using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateWavefrontObjFile.Legoman
{
    class Waist: IObj
    {
        private int density = 50;
		    
        public List<double[]> vertices { get; set; }
        public List<int[]> faces { get; set; }
        public string objModelName { get; set; }
        public void initialiseVerticies()
        {
            vertices = new List<double[]>();

            vertices.Add(new Double[] {4, 0, 7.3});
            vertices.Add(new Double[] {4, 0, -7.3});
            vertices.Add(new Double[] {-4, 0, -7.3});
            vertices.Add(new Double[] {-4, 0, 7.3});

            vertices.Add(new Double[] {4, -2.15, 7.3});
            vertices.Add(new Double[] {4, -2.15, -7.3});
            vertices.Add(new Double[] {-4, -2.15, -7.3});
            vertices.Add(new Double[] {-4, -2.15, 7.3});

            double y1 = -2.15 - 2.9;
            double thetaStep = 72.67211503 / density;
            double theta = 90 - 36.33605751;

            double x;
            double y;

            for (int i = 0; i < (density + 1); i++)
            {
                x = cos_d(theta) * 3.60;
                y = sin_d(theta) * 3.60;

                vertices.Add(new Double[] {x, y1 + y, 7.3});
                vertices.Add(new Double[] {x, y1 + y, .405});

                theta = theta + thetaStep;
            }

            theta = 90 - 36.33605751;

            for (int i = 0; i < (density + 1); i++)
            {
                x = cos_d(theta) * 3.60;
                y = sin_d(theta) * 3.60;

                vertices.Add(new Double[] {x, y1 + y, -7.3});
                vertices.Add(new Double[] {x, y1 + y, -.405});

                theta = theta + thetaStep;
            }

            theta = 10;
            thetaStep = (180 + (theta * 2)) / density;

            for (int i = 0; i < (density + 1); i++)
            {
                x = cos_d(theta) * 3.60;
                y = sin_d(theta) * 3.60;

                vertices.Add(new Double[] {x, y1 + y, 0.405});
                vertices.Add(new Double[] {x, y1 + y, -0.405});

                theta = theta - thetaStep;
            }

            vertices.Add(new Double[] {0, -2.15 - 2.9, 0.405});
            vertices.Add(new Double[] {0, -2.15 - 2.9, -0.405});

            vertices.Add(new Double[] {3.2, -2.15, -0.405});
            vertices.Add(new Double[] {3.2, -2.15, +0.405});
            vertices.Add(new Double[] {-3.2, -2.15, -0.405});
            vertices.Add(new Double[] {-3.2, -2.15, +0.405});

        }
        public void initialiseFaces()
        {
            faces = new List<int[]>();
            // now set up the faces - note that the vertex order is always
            // specified counter-clockwise when that face is viewed front on

            faces.Add(new int[] { 0 + 1, 1 + 1, 2 + 1, 3 + 1 });
            faces.Add(new int[] { 1 + 1, 0 + 1, 4 + 1, 5 + 1 });
            faces.Add(new int[] { 3 + 1, 2 + 1, 6 + 1, 7 + 1 });

            faces.Add(new int[] { 4 + 1, 0 + 1, 8 + 1 });
            faces.Add(new int[] { 3 + 1, 7 + 1, 8 + (density) * 2 + 1 });
            faces.Add(new int[] { 1 + 1, 5 + 1, 8 + (density + 1) * 2 + 1 });
            faces.Add(new int[] { 8 + (density + 1) * 4 - 2 + 1, 6 + 1, 2 + 1 });

            faces.Add(new int[] { 5 + 1, 4 + 1, 8 + 1, 8 + (density + 1) * 2 + 1 });
            faces.Add(new int[] { 8 + (density + 1) * 4 - 2 + 1, 8 + (density) * 2 + 1, 7 + 1, 6 + 1 });

            faces.Add(new int[] { 0 + 1, 3 + 1, 8 + density + 1 });
            faces.Add(new int[] { 2 + 1, 1 + 1, 8 + (density + 1) * 2 + density + 1 });

            for (int i = 0; i < (density); i++)
            {
                faces.Add(new int[] {8 + (density + 1) * 2 + i * 2+1, 9 + (density + 1) * 2 + i * 2+1, 11 + (density + 1) * 2 + i * 2+1,
                                10 + (density + 1) * 2 + i * 2+1});
                faces.Add(new int[] { 10 + i * 2 + 1, 11 + i * 2 + 1, 9 + i * 2 + 1, 8 + i * 2 + 1 });
            }

            for (int i = 0; i < density / 2; i++)
            {
                faces.Add(new int[] { 8 + 2 + i * 2 + 1, 8 + i * 2 + 1, 0 + 1 });
                faces.Add(new int[] { 8 + 2 + i * 2 + density + 1, 8 + i * 2 + density + 1, 3 + 1 });

                faces.Add(new int[] { 1 + 1, 8 + i * 2 + (density + 1) * 2 + 1, 8 + 2 + i * 2 + (density + 1) * 2 + 1 });
                faces.Add(new int[] { 2 + 1, 8 + i * 2 + density + (density + 1) * 2 + 1, 8 + 2 + i * 2 + density + (density + 1) * 2 + 1 });
            }

            for (int i = 0; i < (density); i++)
            {
                faces.Add(new int[] { 8 + (density + 1) * 4 + i * 2 + 2 + 1, 8 + (density + 1) * 4 + i * 2 + 1, vertices.Count - 4 - 2 + 1 });
                faces.Add(new int[] { vertices.Count - 4 - 1 + 1, 8 + (density + 1) * 4 + i * 2 + 1 + 1, 8 + (density + 1) * 4 + i * 2 + 3 + 1 });

                faces.Add(new int[] { vertices.Count - 4 - 2 + 1, 8 + i * 2 + 1 + 1, 8 + i * 2 + 3 + 1 });
                faces.Add(new int[] { vertices.Count - 4 - 1 + 1, 8 + (density + 1) * 2 + i * 2 + 3 + 1, 8 + (density + 1) * 2 + i * 2 + 1 + 1 });

                faces.Add(new int[] {8 + (density + 1) * 4 + i * 2 + 3+1, 8 + (density + 1) * 4 + i * 2 + 1+1, 8 + (density + 1) * 4 + i * 2+1,
                                8 + (density + 1) * 4 + i * 2 + 2+1});
            }

            faces.Add(new int[] { 8 + (density + 1) * 4 + density * 2 + 3 - 3 + 1, vertices.Count - 1 + 1, vertices.Count - 2 + 1, vertices.Count - 4 - 3 + 1 });
            faces.Add(new int[] { 8 + (density + 1) * 4 - 1 + 1, vertices.Count - 5 + 1, vertices.Count - 4 - 3 + 1, vertices.Count - 2 + 1 });
            faces.Add(new int[] { vertices.Count - 1 + 1, 8 + (density + 1) * 4 + density * 2 + 3 - 3 + 1, vertices.Count - 4 - 2 + 1, 8 + (density + 1) * 2 - 1 + 1 });

            faces.Add(new int[] { 8 + (density + 1) * 4 + 1, 8 + (density + 1) * 4 + 1 + 1, vertices.Count - 4 + 1, vertices.Count - 3 + 1 });
            faces.Add(new int[] { 8 + (density + 1) * 4 + 1 + 1, vertices.Count - 5 + 1, 8 + (density + 1) * 2 + 1 + 1, vertices.Count - 4 + 1 });
            faces.Add(new int[] { 8 + 1 + 1, vertices.Count - 4 - 2 + 1, 8 + (density + 1) * 4 + 1, vertices.Count - 3 + 1 });
    
        }
        public void initialiseModelName()
        {
            objModelName = "Waist";
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
