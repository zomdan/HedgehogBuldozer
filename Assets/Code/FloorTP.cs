using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorTP : MonoBehaviour
{

    public Transform placeholder;
    public Transform Player;
    public GameObject Nextbtn;
    
void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Player")) {

        Debug.Log("Player before move: " + Player.transform.position);
        Player.transform.position = placeholder.transform.position;
        Debug.Log("Player after move: " + Player.transform.position);

        Debug.Log("Floor " + transform.parent.name + " Triggered, scene swapped");
        //SceneManager.LoadScene("MiniGame 1");

        Nextbtn.SetActive(true);
        
    }
}

}
