using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateWavefrontObjFile.Library
{
    public class ObjConstructor
    {
        /// <summary>
        /// construct an OBJ file from a list of vertices and faces. Verticies will be constructed first; the faces must be logical 
        /// referencing verticies in the vertices parameter. 
        /// </summary>
        /// <param name="verticies"></param>
        /// <param name="faces"></param>
        /// <param name="outputFilePath"></param>
        public string constructObjFile(List<double[]> vertices,List<int[]> faces, string objModelName)
        {
            var objContents = "g " + objModelName + Environment.NewLine + Environment.NewLine + "# List of vertices" + Environment.NewLine;

            foreach (var vertex in vertices){
                objContents += "v ";
                foreach (var point in vertex)
                {
                    objContents += point.ToString() + " ";
                }
                objContents += Environment.NewLine;
            }

            objContents += Environment.NewLine + "# List of faces" + Environment.NewLine;

            foreach (var face in faces)
            {
                objContents += "f ";
                foreach (var face_vertex in face)
                {
                    objContents += face_vertex.ToString() + " ";
                }
                objContents += Environment.NewLine;
            }

            return objContents;
        }

        public void saveObjToFile(string objContents, string filePath)
        {
            System.IO.File.WriteAllText(filePath, objContents);
        }
    }
}
