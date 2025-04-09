using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowToggle : MonoBehaviour
{
    private Material originalMaterial;
    public Material glowMaterial;
    private bool isGlowing = false;

    void Start()
    {
        originalMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Toggle with key press (G for Glow)
        if (Input.GetKeyDown(KeyCode.G))
        {
            ToggleGlow();
        }
    }

    void ToggleGlow()
    {
        var renderer = GetComponent<Renderer>();
        isGlowing = !isGlowing;
        renderer.material = isGlowing ? glowMaterial : originalMaterial;
    }
}
