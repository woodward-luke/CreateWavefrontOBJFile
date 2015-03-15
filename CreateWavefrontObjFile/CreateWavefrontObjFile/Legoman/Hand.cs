using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateWavefrontObjFile.Legoman
{
    class Hand: IObj
    {
        private int density = 50;
		    
        public List<double[]> vertices { get; set; }
        public List<int[]> faces { get; set; }
        public string objModelName { get; set; }
        public void initialiseVerticies()
        {
            vertices = new List<double[]>();

            // the number of degrees per radian
            const double degPerRad = 180 / 3.141592654;

            double outerRadius = 2.50;
            double innerRadius = 1.90;
            double handwidth = 3;
            double gapangle = 90;
            double angleStep = (360 - gapangle) / density;
            double theta = 0 - 90 + gapangle / 2;

            double x;
            double y;

            for (int i = 0; i < density; i++)
            {
                x = cos_d(theta);
                y = sin_d(theta);

                vertices.Add(new Double[] {x * innerRadius, y * innerRadius, handwidth});
                if (y >= 0)
                    vertices.Add(new Double[] {x * innerRadius, y * innerRadius, 0});
                else
                    vertices.Add(new Double[] {x * innerRadius, y * innerRadius, 0 + y * y * 2.5});
                theta = theta + angleStep;
            }

            theta = 0 - acos(cos_d(-90 + gapangle / 2) * innerRadius / outerRadius) * degPerRad;
            angleStep = (360 - (90 + theta) * 2) / density;
            //angleStep = (360 - gapangle) / density;

            for (int i = 0; i < density; i++)
            {
                x = cos_d(theta);
                y = sin_d(theta);

                vertices.Add(new Double[] {x * outerRadius, y * outerRadius, handwidth});
                if (y >= 0)
                    vertices.Add(new Double[] {x * outerRadius, y * outerRadius, 0});
                else
                    vertices.Add(new Double[] {x * outerRadius, y * outerRadius, 0 + y * y * 2});
                theta = theta + angleStep;
            }
        }
        public void initialiseFaces()
        {
            faces = new List<int[]>();
            // now set up the faces - note that the vertex order is always
            // specified counter-clockwise when that face is viewed front on

            for (int i = 0; i < (density) * 2 - 2; i = i + 2)
            {
                faces.Add(new int[] {i + 2, i + 3, i + 1, i});
                faces.Add(new int[] {density * 2 + i, density * 2 + i + 1, density * 2 + i + 3, density * 2 + i + 2});
                faces.Add(new int[] {density * 2 + i + 3, density * 2 + i + 1, i + 1, i + 3});
                faces.Add(new int[] {density * 2 + i + 0, density * 2 + i + 2, i + 2, i});
            }

            faces.Add(new int[] {1, density * 2 + 1, density * 2, 0});
            faces.Add(new int[] {density * 4 - 2, density * 4 - 1, density * 2 - 1, density * 2 - 2});
	
            for (int f = 0; f < faces.Count; f++)
            {
                for (int i = 0; i < faces[f].Count(); i++)
                {
                    faces[f][i] = faces[f][i] + 1;
                }
            }
    
        }
        public void initialiseModelName()
        {
            objModelName = "Hand";
        }
        public double cos_d(double angle_degrees)
        {
            return Math.Cos(Math.PI * angle_degrees / 180.0);
        }
        public double sin_d(double angle_degrees)
        {
            return Math.Sin(Math.PI * angle_degrees / 180.0);
        }
        public double acos(double angle_degrees)
        {
            return Math.Acos(angle_degrees);
            //return Math.Acos(Math.PI * angle_degrees / 180.0);
        }
    }
}
