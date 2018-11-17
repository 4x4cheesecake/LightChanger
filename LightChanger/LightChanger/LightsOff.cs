using System.Linq;
using UnityEngine;
using System.Collections.Generic;

namespace LightChanger
{
    [KSPAddon(KSPAddon.Startup.MainMenu, false)]
    public class LightsOff : MonoBehaviour
    {
        public void Start()
        {
            ChangeLight();
        }
        
        public void ChangeLight()
        {
            string lightname;

            //Create list (for all light objects)
            List<Light> Light_list = new List<Light>();

            //populate list
            Light_list = FindObjectsOfType<Light>().ToList();

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
