using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowToggle : MonoBehaviour
{
    private Material normalMaterial;
    public Material glowMaterial;
    private bool isGlowing = false;

    void Start()
    {
        normalMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ToggleGlow();
        }
    }

    void ToggleGlow()
    {
        var renderer = GetComponent<Renderer>();
        isGlowing = !isGlowing;
        renderer.material = isGlowing ? glowMaterial : normalMaterial;
    }
}
