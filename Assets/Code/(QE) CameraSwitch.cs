using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public List<GameObject> cameras;
    private int activeCameraIndex = 0;
    private float lastSwitchTime = 0f;
[SerializeField] private float switchDelay;


    void Start()
    {
        if (cameras.Count > 0) 
        {
            ActivateCamera(activeCameraIndex);
        }
    }

    void Update()
    {
        if (Time.time - lastSwitchTime >= switchDelay)
        //current time - time at last switch >= 1s(or whatever u set it to)
        {
            if (Input.GetKeyDown(KeyCode.Q)) //prevcam
            {
                SwitchCamera((activeCameraIndex - 1 + cameras.Count) % cameras.Count);
            }
            else if (Input.GetKeyDown(KeyCode.E)) //nextcam
            {
                SwitchCamera((activeCameraIndex + 1) % cameras.Count);
            }

        }


            if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetMouseButtonDown(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    void SwitchCamera(int index)
    {
        if (index >= 0 && index < cameras.Count)
        {
            activeCameraIndex = index;
            ActivateCamera(activeCameraIndex);
            lastSwitchTime = Time.time;
        }
    }

    void ActivateCamera(int index)
    {
        for (int i = 0; i < cameras.Count; i++)
        {  if (i == index)
        {cameras[i].SetActive(true);  }
           else 
        {cameras[i].SetActive(false);}
        }
    }
}
