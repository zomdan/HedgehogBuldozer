using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyCam : MonoBehaviour
{
    [SerializeField] private Camera flyCam;

    [SerializeField] private Camera startCam;
    [SerializeField] private Camera targetCam;
    [SerializeField] private float flySpeed = 2f;

    [SerializeField] private float flyDelay = 2f;

    [SerializeField] private GameObject targetCamController;

    [SerializeField] private GameObject thisButton;

    private bool isFlying = false;
    private float flyPercent = 0f;

    void Update()
    {
        if (isFlying)
        {
            flyPercent += Time.deltaTime * flySpeed;
            flyCam.transform.position = Vector3.Lerp(flyCam.transform.position, targetCam.transform.position, flyPercent);
            flyCam.transform.rotation = Quaternion.Lerp(flyCam.transform.rotation, targetCam.transform.rotation, flyPercent);

            if (flyPercent >= 1f)
            {
                isFlying = false;
                OnFlyEnd();
            }
        }
    }

    public void FlySetup(){
        flyCam.transform.SetPositionAndRotation(startCam.transform.position, startCam.transform.rotation);
        flyCam.transform.localScale = startCam.transform.localScale;
        Invoke("StartFlying", flyDelay);
        }

    public void StartFlying()
    {
        Debug.Log("Flying transition started.");
        flyPercent = 0f;
        isFlying = true;
    }

    private void OnFlyEnd()
    {
        Debug.Log("Flying transition ended.");
        flyCam.gameObject.SetActive(false);
            Debug.Log("FlyCam Disabled.");
        

        targetCamController.SetActive(true);
        gameObject.SetActive(false);
        thisButton.SetActive(false);
            Debug.Log("Switched Camera Controller.");

    }
}
