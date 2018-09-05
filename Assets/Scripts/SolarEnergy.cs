using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SolarEnergy : MonoBehaviour
{
    float maxEnergy;
    float currentEnergy = 15;
    float minEnergy;
    public PostProcessVolume energy;
    Bloom bloom;
    // Use this for initialization
    void Start()
    {
        bloom = ScriptableObject.CreateInstance<Bloom>();
        bloom.enabled.Override(true);
        bloom.intensity.Override(currentEnergy);

        energy = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, bloom);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
