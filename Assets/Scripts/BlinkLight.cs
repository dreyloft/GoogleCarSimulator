using UnityEngine;
using System.Collections;

public class BlinkLight : MonoBehaviour {

    [SerializeField]
    Light[] _lights = new Light[2];

    void Start()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Light");
        for (int i = 0; i < gos.Length; i++) _lights[i] = gos[i].GetComponent<Light>();
        InvokeRepeating("Blink", 0.01f, .5f);
    }
    void Blink()
    {
        foreach (Light lgt in _lights) lgt.enabled = !lgt.enabled;
    }

}
