using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerEffectManager : MonoBehaviour
{
    public int targetLayer = 7; // Replace with your layer number
    public Material glowMaterial;

    void Start()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            if (obj.layer == targetLayer)
            {
                var renderer = obj.GetComponent<MeshRenderer>();
                if (renderer != null)
                {
                    renderer.material = glowMaterial;
                }
            }
        }
    }
}
