using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Flicker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FlickerLight());
    }

    IEnumerator FlickerLight()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(0.5f, 3f));
            GetComponent<Light2D>().enabled = false;
            yield return new WaitForSeconds(0.05f);
            GetComponent<Light2D>().enabled = true;
        }
    }
}
