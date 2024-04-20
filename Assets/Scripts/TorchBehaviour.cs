using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchBehaviour : MonoBehaviour
{
    private new Light2D light;
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
        Flicker();
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
            light.pointLightOuterRadius = strength/2 + 4.5f;

            flickerTimer = 0f;
        }
    }
}
