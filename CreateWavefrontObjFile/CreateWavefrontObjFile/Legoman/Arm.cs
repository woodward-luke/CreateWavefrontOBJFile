using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateWavefrontObjFile.Legoman
{
    class Arm: IObj
    {
        private int density = 50;
		    
        public List<double[]> vertices { get; set; }
        public List<int[]> faces { get; set; }
        public string objModelName { get; set; }
        public void initialiseVerticies()
        {
            vertices = new List<double[]>();

            double theta = 0.00;
            double thetaStep = 90.0f / density;

            double armradius = 1.0f;
            double armwidth = 1.0f;
            double armheight = 1.0f;

            double x;
            double y;
            double z;

            double zrot;
            double yrot;

            for (int i = 0; i < (density); i++)
            {
                x = armwidth / 2 + cos_d(theta) * armradius;
                y = armheight / 2 + sin_d(theta) * armradius;

                vertices.Add(new Double[] {x, -6 + y, -8});
                vertices.Add(new Double[] {-x, -6 + y, -8});
                vertices.Add(new Double[] {-x, -6 - y, -8});
                vertices.Add(new Double[] {x, -6 - y, -8});

                theta = theta + thetaStep;
            }

            theta = 0;
            z = -3.5;

            for (int i = 0; i < (density); i++)
            {
                x = armwidth / 2 + cos_d(theta) * armradius * 1.4;
                y = armheight * 1.2 / 2 + sin_d(theta) * armradius * 1.4;

                zrot = (0 * cos_d(55) - y * sin_d(55));
                yrot = (0 * sin_d(55) + y * cos_d(55)) * 1.3;

                vertices.Add(new Double[] {x, -6 + yrot, z + zrot});
                vertices.Add(new Double[] {-x, -6 + yrot, z + zrot});
                vertices.Add(new Double[] {-x, -6 - yrot, z - zrot});
                vertices.Add(new Double[] {x, -6 - yrot, z - zrot});

                theta = theta + thetaStep;
            }

            z = 0;
            theta = 45;
            thetaStep = theta / density;

            double theta2 = 0.00000;
            double theta2step = 180.0000 / density;
            double radius;
            double slope = 0.00;
            double step = 90.00 / density;

            for (int j = 0; j < density; j++)
            {

                radius = armwidth / 2 + sin_d(slope) * armradius;
                theta2 = 0.000;
                slope = slope + step;

                for (int i = 0; i < density; i++)
                {
                    y = sin_d(theta2) * radius * 1.4;
                    x = cos_d(slope) * armradius * 1.4 + 0.2 * (1 - y / radius) * (1 - (cos_d(theta) * armradius * 1.5) /
                                (armradius * 1)) + 0.075;
                    z = cos_d(theta2) * radius * 1.4;

                    zrot = z * cos_d(145) - y * sin_d(145);
                    yrot = z * sin_d(145) + y * cos_d(145);

                    vertices.Add(new Double[] {x, -yrot, -zrot});
                    vertices.Add(new Double[] {-x, -yrot, -zrot});
                    theta2 = theta2 + theta2step;
                }
                theta = theta + thetaStep;
            }

            vertices.Add(new Double[] {0, -6, -8});
            vertices.Add(new Double[] {armradius * 1.4 + 0.075, 0, 0});
            vertices.Add(new Double[] {-(armradius * 1.4 + 0.075), 0, 0});


        }
        public void initialiseFaces()
        {
            faces = new List<int[]>();
            // now set up the faces - note that the vertex order is always
            // specified counter-clockwise when that face is viewed front on
            for (int i = 0; i < (density - 1) * 4; i = i = i + 4)
            {
                faces.Add(new int[] {vertices.Count - 3, i + 4, i});
                faces.Add(new int[] {vertices.Count - 3, i + 1, i + 5});
                faces.Add(new int[] {vertices.Count - 3, i + 6, i + 2});
                faces.Add(new int[] {vertices.Count - 3, i + 3, i + 7});
            }

            faces.Add(new int[] {vertices.Count - 3, 0, 3});
            faces.Add(new int[] {vertices.Count - 3, 2, 1});
            faces.Add(new int[] {vertices.Count - 3, density * 4 - 1, density * 4 - 2});
            faces.Add(new int[] {vertices.Count - 3, density * 4 - 3, density * 4 - 4});

            for (int i = 0; i < (density - 1) * 4; i = i + 4)
            {
                faces.Add(new int[] {i, i + 4, density * 4 + i + 4, density * 4 + i});
                faces.Add(new int[] {density * 4 + i + 1, density * 4 + i + 4 + 1, i + 4 + 1, i + 1});
                faces.Add(new int[] {i + 2, i + 4 + 2, density * 4 + i + 4 + 2, density * 4 + i + 2});
                faces.Add(new int[] {density * 4 + i + 3, density * 4 + i + 4 + 3, i + 4 + 3, i + 3});
            }

            faces.Add(new int[] {density * 4, density * 4 + 3, 3, 0});
            faces.Add(new int[] {1, 2, density * 4 + 2, density * 4 + 3 + 2});
            faces.Add(new int[] {density * 8 - 3, density * 8 - 4, density * 4 - 4, density * 4 - 3});
            faces.Add(new int[] {density * 4 - 2, density * 4 - 1, density * 8 - 1, density * 8 - 2});

            int n1 = 0, n2 = 0;
            for (int i = 0; i < density - 1; i++)
            {
                n2 = n1 * 4;
                faces.Add(new int[] {density * 8 + density * 2 * n2 / 4,
                                density * 8 + density * 2 * n2 / 4 + density * 2, density * 4 + 4 + 3 + n2, density * 4 + 3 + n2});
                faces.Add(new int[] {density * 4 + 2 + n2, density * 4 + 4 + 2 + n2,
                                density * 8 + 1 + density * 2 * n2 / 4 + density * 2, density * 8 + 1 + density * 2 * n2 / 4});
                faces.Add(new int[] {density * 8 + density * 2 * n2 / 4 + density * 2 - 1,
                                density * 8 + density * 4 - 1 + density * 2 * n2 / 4, density * 4 + 4 + 1 + n2, density * 4 + 1 + n2});
                faces.Add(new int[] {density * 4 + n2, density * 4 + 4 + n2,
                                density * 8 + density * 4 - 2 + density * 2 * n2 / 4, density * 8 + density * 2 * n2 / 4 + density * 2 - 2});
                n1++;
            }

            faces.Add(new int[] {density * 8 + density * 2 - 2, density * 8, density * 4 + 3, density * 4});
            faces.Add(new int[] {density * 4 + 3 + 2, density * 4 + 2, density * 8 + 1, density * 8 + density * 2 - 1});
            faces.Add(new int[] {density * 8 + density * 2 * (density - 1),density * 8 + density * 2 * (density - 1) + 1, density * 8 - 2, density * 8 - 1});
            faces.Add(new int[] {density * 8 - 4, density * 8 - 3, density * 8 + density * 2 * density - 1, density * 8 + density * 2 * density - 2});

            for (int i = 0; i < (density) * (density - 1) - 1; i++)
            {
                faces.Add(new int[] {density * 8 + density * 2 + 2 + i * 2, density * 8 + density * 2 + i * 2, density * 8 + i * 2, density * 8 + 2 + i * 2});
                faces.Add(new int[] {density * 8 + 2 + i * 2 + 1, density * 8 + i * 2 + 1, density * 8 + density * 2 + i * 2 + 1, density * 8 + density * 2 + 2 + i * 2 + 1});
            }

            for (int i = 0; i < density; i++)
            {
                faces.Add(new int[] {density * 8 + 2 + 2 * i, density * 8 + 2 * i, vertices.Count - 2});
                faces.Add(new int[] {vertices.Count - 1, density * 8 + 1 + 2 * i, density * 8 + 3 + 2 * i});

            }

            for (int i = 0; i < density - 1; i++)
            {
                faces.Add(new int[] {density * 8 + density * density * 2 - 3 - i * 2, density * 8 + density * density * 2 - 4 - i * 2, density * 8 + density * density * 2 - 2 - i * 2, density * 8 + density * density * 2 - 1 - i * 2});
            }


            for(int f= 0; f < faces.Count; f++)
            {
                for (int i = 0; i < faces[f].Count(); i++)
                {
                    faces[f][i] = faces[f][i] + 1;
                }
            }
        }

        public void initialiseModelName()
        {
            objModelName = "Arm";
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
