using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class TorchBehaviour : MonoBehaviour
{
    private new Light2D light;
    bool on = true;
    // Start is called before the first frame update
    void Awake()
    {
        if (light == null)
        {
            light = GetComponent<Light2D>();
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (on)
            Flicker();
    }

    public void OnConceal(InputAction.CallbackContext context){
        if (context.started)
        {
            Conceal();
        }
        if (context.canceled)
        {
            Reveal();
        }
    }

    public void Reveal()
    {
        on = true;
        light.intensity = 1;
        light.pointLightOuterRadius = 1;
    }

    public void Conceal()
    {
        on = false;
        light.intensity = 0;
        light.pointLightOuterRadius = 0;
    }

    private float flickerSpeed = 0.1f;
    private float flickerTimer = 0f;

    void Flicker()
    {
        flickerTimer += Time.deltaTime;

        if (flickerTimer >= flickerSpeed)
        {
            float strength = Random.Range(0.8f, 1.2f);
            light.intensity = strength;
            light.pointLightOuterRadius = strength/2 + 2.5f;

            flickerTimer = 0f;
        }
    }
}
