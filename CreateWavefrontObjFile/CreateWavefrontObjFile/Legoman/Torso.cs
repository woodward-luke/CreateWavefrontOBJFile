using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateWavefrontObjFile.Legoman
{
    class Torso: IObj
    {
        private int density = 50;
		    
        public List<double[]> vertices { get; set; }
        public List<int[]> faces { get; set; }
        public string objModelName { get; set; }
        public void initialiseVerticies()
        {
            vertices = new List<double[]>();
            double angleStep = 80.0f / density;
            double theta = 90.0f;

            //four base verticies
            vertices.Add(new Double[] { 4, 0, 7.72 });
            vertices.Add(new Double[] { -4, 0, 7.72 });
            vertices.Add(new Double[] { -4, 0, -7.72 });
            vertices.Add(new Double[] { 4, 0, -7.72 });

            //curve at top corners of the torso
            for (int j = 0; j < density; j++)
            {
                double y = 12 + sin_d(theta);
                double z = 4.87 + cos_d(theta);

                vertices.Add(new Double[] { 4, y, z });
                vertices.Add(new Double[] { -4, y, z });
                vertices.Add(new Double[] { -4, y, -z });
                vertices.Add(new Double[] { 4, y, -z });

                theta = theta - angleStep;
            }
        }
        public void initialiseFaces()
        {
            faces = new List<int[]>();
            // now set up the faces - note that the vertex order is always
            // specified counter-clockwise when that face is viewed front on

            //box structure that makes up the base of the torso
            faces.Add(new int[] { 2 + 1, 1 + 1, 4 + density * 4 - 3 + 1, 4 + density * 4 - 2 + 1 });
            faces.Add(new int[] { 0 + 1, 3 + 1, 4 + density * 4 - 1 + 1, 4 + density * 4 - 4 + 1 });
            faces.Add(new int[] { 3 + 1, 2 + 1, 4 + density * 4 - 2 + 1, 4 + density * 4 - 1 + 1 });
            faces.Add(new int[] { 4 + density * 4 - 4 + 1, 4 + density * 4 - 3 + 1, 1 + 1, 0 + 1 });
            faces.Add(new int[] { 0 + 1, 1 + 1, 2 + 1, 3 + 1 });
            faces.Add(new int[] { 7 + 1, 6 + 1, 5 + 1, 4 + 1 });

            //initialises faces in strips connecting the curved top corners of the torso
            for (int i = 0; i < (density - 1); i++)
            {
                faces.Add(new int[] { 4 + i * 4 + 1, 4 + i * 4 + 1 + 1, 4 + i * 4 + 1 + 4 + 1, 4 + i * 4 + 4 + 1 });
                faces.Add(new int[] { 4 + i * 4 + 1 + 1, 4 + i * 4 + 2 + 1, 4 + i * 4 + 1 + 5 + 1, 4 + i * 4 + 5 + 1 });
                faces.Add(new int[] { 4 + i * 4 + 2 + 1, 4 + i * 4 + 3 + 1, 4 + i * 4 + 1 + 6 + 1, 4 + i * 4 + 6 + 1 });
                faces.Add(new int[] { 4 + i * 4 + 3 + 1, 4 + i * 4 + 4 - 4 + 1, 4 + i * 4 + 1 + 7 - 4 + 1, 4 + i * 4 + 7+1 });
            }
            
        }
        public void initialiseModelName()
        {
            objModelName = "Torso";
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
