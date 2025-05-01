using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    [SerializeField] private float range = 30f;
    public LineRenderer lineRenderer; // laser bc im bored
    [SerializeField] private int GlowLayer = 7;

    void Start()
        {

            //laser stuff
            if (lineRenderer == null){   
                 lineRenderer = GetComponent<LineRenderer>(); lineRenderer.positionCount = 2; }
        }

void Update()
{
    //laser stuff
    Vector3 startPos = transform.position;
    Vector3 direction = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0)).direction;
    Vector3 endPos = startPos + direction * range;

    if (Physics.Raycast(startPos, direction, out /*output bleh*/ RaycastHit hit /*thing it hit*/, range)){
        endPos = hit.point;

        // Check for RayCastable on Click
        if (hit.collider.CompareTag("RayCastable"))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("omg i just touched a " + hit.collider.name + " uwu");
                GameObject hitObject = hit.collider.gameObject;
                Debug.Log("Old Layer: " + hitObject.layer);
                hitObject.layer = GlowLayer;
                Debug.Log("New Layer: " + hitObject.layer);
            }
        }
    }

    lineRenderer.SetPosition(0, startPos); // first position yayy
    lineRenderer.SetPosition(1, endPos);   
    //  the same thing as last line but for the end. im hyper explaining everything but im dumb sometimes <3
}


}