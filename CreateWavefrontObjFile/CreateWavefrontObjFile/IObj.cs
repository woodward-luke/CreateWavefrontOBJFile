using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateWavefrontObjFile
{
    interface IObj
    {
        List<double[]> vertices {get; set;}
        List<int[]> faces { get; set; }
        string objModelName { get; set; }
        void initialiseModelName();
        void initialiseVerticies();
        void initialiseFaces();
    }
}
