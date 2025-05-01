using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamController : MonoBehaviour
{


    // Camera objects & related
    public List<GameObject> cameras; // If it gives error multiple Listeners in one scene, maybe you're forgetting to input this in the script.
    private int activeCameraIndex = 0;
    
    //init:
    private Transform CamBody;
    public Transform Camera;
        // Camera Angle Limits  - X angles are calculated dynamically later, you just need to enter the initial values to use in this case.
    private float Yrot = -45f; // current obj Y rotation.
    [SerializeField] private float minY = -25f; 
    [SerializeField] private float maxY = 65f;  
    [SerializeField] private float verticalLookRange = 45f;
    private float minX = -90f;
    private float maxX = 0f; 

    // Camera Switching Settings
    private float lastSwitchTime = 0f;
    private float switchDelay = 0.3f;

    // Camera Angles Misc
    private float rotationX = 0f;
    private float rotationY = 0f;
    private float mouseSensitivity = 2.0f;

    //Color Modes
    [SerializeField] private List<GameObject> colormodes;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        cameras[0].SetActive(true);
        for (int i = 0; i < cameras.Count; i++)
        {	if (i!= activeCameraIndex){
                cameras[i].SetActive(false); }
        }

        CamBody = Camera.parent;
        Yrot = Camera.transform.eulerAngles.y;
        float Xrot = transform.eulerAngles.x;
        minX = Xrot - verticalLookRange;
        maxX = Xrot + verticalLookRange;

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //move cursor around on esc
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Input.GetMouseButtonDown(1)) // go back to locked cursor
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        
        HandleCameraRotation();

        if (Time.time - lastSwitchTime >= switchDelay)
        //current time - time at last switch >= 1s(or whatever u set it to)
        {
            if (Input.GetKeyDown(KeyCode.Q)) //prevcam
            {
                Debug.Log("prevcam");
                SwitchCamera((activeCameraIndex - 1 + cameras.Count) % cameras.Count);
            }
            else if (Input.GetKeyDown(KeyCode.E)) //nextcam
            {
                Debug.Log("nextcam");
                SwitchCamera((activeCameraIndex + 1) % cameras.Count);
                
            }
            else if (Input.GetKeyDown(KeyCode.Space)) //nextcolormode
            {
                Debug.Log("nextcolormode");
                SwitchColorMode();
                
            }

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
        {cameras[i].SetActive(true);  
         Camera = cameras[i].transform;
         CamBody = cameras[i].transform.parent;
         Yrot = cameras[i].transform.eulerAngles.y;
        minX = Yrot - verticalLookRange; maxX = Yrot + verticalLookRange; // so it controls the rotation limits dynamically
        }
           else 
        {cameras[i].SetActive(false);}
        }
    }


        private void HandleCameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Vertical rotation (On the camera)
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minY, maxY);
        Camera.localRotation = Quaternion.Euler(rotationX, 0, 0);
        /* Since it rotates along the x AXIS thats why it controls up and down. 
        It still confuses me since I'm not used to thinking of it that way but I'm trying to get used to it ^-^*/


        // Horizontal rotation (On the body)
        rotationY += mouseX;
        rotationY = Mathf.Clamp(rotationY, minX, maxX);
        CamBody.localRotation = Quaternion.Euler(0, rotationY, 0);
        /*Same thing here but it's Y axis. I'm not going to try to explain Quaternions and Euler Angles 
        because I've looked it up a million times and still don't get it because I suck at math. 
        But it just works that way so I'm gonna utilize it*/
    }

    void SwitchColorMode(){ 
    for (int i = 0; i < colormodes.Count; i++){
        if (colormodes[i].activeSelf){
            colormodes[i].SetActive(false);
            if (i != colormodes.Count - 1) colormodes[i + 1].SetActive(true);
            else colormodes[0].SetActive(true);
            return;
            }
        }
    }
        // maybe getsets idk my brains not working rn

}
