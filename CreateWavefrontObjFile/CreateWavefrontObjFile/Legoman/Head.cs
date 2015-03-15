using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateWavefrontObjFile.Legoman
{
    class Head: IObj
    {
          
        public List<double[]> vertices { get; set; }
        public List<int[]> faces { get; set; }
        public string objModelName { get; set; }
        int density = 50;
        int bevelSteps = 50;

        public void initialiseVerticies()
        {
            vertices = new List<double[]>();

            for (int j = 0; j < density; j++)
            {
                // calculate angle around Y axis
                double kRot = j * (360.0 / density);

                // calculate x, y & z coordinates
                double x1 = cos_d(kRot);
                double z1 = sin_d(kRot);
                double y1 = 0;
                double y2 = 4.86f;
                double x;
                double z;
                double y;

                // rotating around Z axis by this amount
                double stepSize = 90.0 / bevelSteps;
                // starting Z rot near top;
                double theta = 90.0;

                vertices.Add(new Double[] { x1 * 1.54, y2 + 1.75, z1 * 1.54 });
                vertices.Add(new Double[] { x1 * 1.54, y2 + 1.75 + 1, z1 * 1.54 });
                vertices.Add(new Double[] { x1 * 2.44, y2 + 1.75 + 1, z1 * 2.44 });
                vertices.Add(new Double[] { x1 * 2.44, y2 + 1.75, z1 * 2.44 });

                //upper curve of head
                for (int k = 0; k < bevelSteps; k++)
                {
                    // calculate x, y & z coordinates
                    x = 1.75 * cos_d(theta) * cos_d(kRot);
                    z = 1.75 * cos_d(theta) * sin_d(kRot);
                    y = 1.75 * sin_d(theta);

                    vertices.Add(new Double[] { x1 * 3.3 + x, y2 + y, z1 * 3.3 + z });
                    theta = theta - stepSize;
                }

                theta = 0;

                //lower curve of head
                for (int k = 0; k < bevelSteps; k++)
                {
                    // calculate x, y & z coordinates
                    x = 1.75 * cos_d(theta) * cos_d(kRot);
                    z = 1.75 * cos_d(theta) * sin_d(kRot);
                    y = 1.75 * sin_d(theta);

                    vertices.Add(new Double[] { x1 * 3.3 + x, y1 + y, z1 * 3.3 + z });
                    theta = theta - stepSize;
                }

                //bottom of neck
                vertices.Add(new Double[] { x1 * 3.25, -1.75, z1 * 3.25 });
                vertices.Add(new Double[] { x1 * 3.25, -1.75 - 1.21, z1 * 3.25 });

                kRot = kRot + stepSize;
            }

            vertices.Add(new Double[] { 0, 4.86 + 1.75, 0 });
            vertices.Add(new Double[] { 0, -1.75 - 1.21, 0 });

        }
        public void initialiseFaces()
        {
            faces = new List<int[]>();
            // now set up the faces - note that the vertex order is always
            // specified counter-clockwise when that face is viewed front on
            int shift=bevelSteps*2+6;
			    for (int j=0;j<(density-1);j++)
			    {
			        for (int i = 0; i<(bevelSteps*2+5); i ++)
			        {
			            faces.Add(new int[] {shift*j+i+bevelSteps*2+6 + 1,shift*j+i+bevelSteps*2+7 +1,
			                            shift*j+i+1 +1, shift*j+i +1});
			        }
			    }
			    
			    for(int i = 0; i<(density-1);i++)
			    {
                    faces.Add(new int[] { shift * i + shift + 1, shift * i + 1, vertices.Count - 2 + 1 });
                    faces.Add(new int[] { vertices.Count - 1 + 1, shift * i + shift - 1 + 1, shift * i + shift * 2 - 1 + 1 });
			    }
			    
			    for (int i = 0; i<(bevelSteps*2+5); i ++)
			    {
                    faces.Add(new int[] { i + 1 + 1, shift * (density - 1) + 1 + i + 1, shift * (density - 1) + i + 1, i + 1 });
			    }

                faces.Add(new int[] { 0 + 1, shift * (density - 1) + 1, vertices.Count - 2 + 1 });
                faces.Add(new int[] { vertices.Count - 1 + 1, shift * density - 1 + 1, shift - 1 + 1 });
        }
        public void initialiseModelName()
        {
            objModelName = "Head";
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
