using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateWavefrontObjFile
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IObj> models = new List<IObj>();

            
            var waist = new Legoman.Waist();
            waist.initialiseModelName();
            waist.initialiseVerticies();
            waist.initialiseFaces();
            models.Add(waist);

            var head = new Legoman.Head();
            head.initialiseModelName();
            head.initialiseVerticies();
            head.initialiseFaces();
            models.Add(head);

            var leg = new Legoman.Leg();
            leg.initialiseModelName();
            leg.initialiseVerticies();
            leg.initialiseFaces();
            models.Add(leg);

            var torso = new Legoman.Torso();
            torso.initialiseModelName();
            torso.initialiseVerticies();
            torso.initialiseFaces();
            models.Add(torso);

            var arm = new Legoman.Arm();
            arm.initialiseModelName();
            arm.initialiseVerticies();
            arm.initialiseFaces();
            models.Add(arm);
            

            var hand = new Legoman.Hand();
            hand.initialiseModelName();
            hand.initialiseVerticies();
            hand.initialiseFaces();
            models.Add(hand);

            var wrist = new Legoman.Wrist();
            wrist.initialiseModelName();
            wrist.initialiseVerticies();
            wrist.initialiseFaces();
            models.Add(wrist);

            foreach (var model in models)
            {
                CreateWavefrontObjFile.Library.ObjConstructor objCon = new Library.ObjConstructor();
                var objContents = objCon.constructObjFile(model.vertices, model.faces, model.objModelName);
                objCon.saveObjToFile(objContents, @"C:\" + model.objModelName + ".obj");
            }

            
        }
    }
}
