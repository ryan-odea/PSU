using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonControl : MonoBehaviour
{
    private bool on = false;
    private bool buttonHit = false;
    private GameObject button;

    private float buttonDownDistance = 0.025f;
    private float buttonOriginalY;

    private Material originalMaterial = null;
    private MeshRenderer meshRenderer = null;

    public Material selectMaterial = null;

    void Start()
    {
        buttonOriginalY = button.transform.position.y;
    }

    void Update()
    {
    if (buttonHit == true)
        {
            buttonHit = false;
            on = !on;

            button.transform.position = new Vector3(button.transform.position.x, button.transform.position.y - buttonDownDistance, button.transform.position.z);

            if(on)
            {
                meshRenderer.material = selectMaterial;
            } else {
                meshRenderer.material = originalMaterial;
            }
        }
    }
}