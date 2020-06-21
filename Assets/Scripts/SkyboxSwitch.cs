using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxSwitch : MonoBehaviour
{
    public Material[] skybox;

    GameObject obj;

    bool switchBool;

    private void Update()
    {
        obj.SetActive(false);

        if(switchBool)
            RenderSettings.skybox = skybox[1];
        else
            RenderSettings.skybox = skybox[0];

        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switchBool = !switchBool;
            }
        }
        
    }
}
