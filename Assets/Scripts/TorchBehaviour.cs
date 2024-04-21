using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class TorchBehaviour : MonoBehaviour
{
    private new Light2D light;
    bool on = true;

    public Transform anchorObj;

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

	private void LateUpdate()
	{
        if (anchorObj)
        {
            var pos = anchorObj.position;
            pos.z = 6;
			transform.position = pos;
        }
	}

	public void OnConceal(InputAction.CallbackContext context){
        if (context.started)
		{
			Reveal();
		}
        if (context.canceled)
		{
			Conceal();
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

    public float flickerSpeed = 0.1f;
    private float flickerTimer = 0f;

    public bool smooth = true;
    private float t;
    private float targetStrength = 1;
    private float targetRadius = 3;

    void Flicker()
    {
        flickerTimer += Time.deltaTime;

		if (flickerTimer >= flickerSpeed)
        {
			targetStrength = Random.Range(0.8f, 1.2f);
            targetRadius = targetStrength / 2 + 2.5f;

			if (!smooth)
			{
                light.intensity = targetStrength;
                light.pointLightOuterRadius = targetStrength / 2 + 2.5f;
            }

            flickerTimer = 0f;
        }

        if (smooth)
        {
		    t = Mathf.Clamp01( 1 - (flickerSpeed - flickerTimer) / flickerSpeed );
            light.intensity = Mathf.MoveTowards(light.intensity, targetStrength, t);
            light.pointLightOuterRadius = Mathf.MoveTowards(light.pointLightOuterRadius, targetRadius, t);
        }
	}
}
