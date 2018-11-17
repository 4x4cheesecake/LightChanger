//using System;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
using UnityEngine;

namespace LightChanger
{
    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    public class LightsOff
    {
        public void Start()
        {

        }
        
        public void ChangeLight()
        {
            string lightname;

            //Create list (for all light objects)
            List<Light> Light_list = new List<Light>();

            //populate list
            Light_list = Object.FindObjectsOfType<Light>().ToList();

            //KSP 1.5 added a few new ligts in the Main Menu and changed a property of the sunlight
            //iterate through the whole list, looking for additional lights and destroy them
            //also look for the sunlight and change the cullingmask property back to the old value

            foreach (Light LightObject in Light_list)
            {
                lightname = LightObject.name.ToString();

                if (lightname == "BackLight")
                {                    
                    Destroy(LightObject);
                }
                else if (lightname == "FillLight")
                {         
                    Destroy(LightObject);
                }
                else if (lightname == "KeyLight")
                {
                    Destroy(LightObject);
                }
                else if (lightname == "PlanetLight")
                {
                    LightObject.cullingMask = -1;
                }
            }
        }
    }
}
