using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParticleController : MonoBehaviour
{

    public Slider rainDensitySlider;
    public void StopParticls(ParticleSystem rain)
    {
        if (rain.isStopped)
        {
            rain.Play();
        }
        else
        {
            rain.Stop();
        }
    }

    public void ParticleDensity(ParticleSystem rain)
    {
        var emission = rain.emission;
        emission.rateOverTime = rainDensitySlider.value;
    }
}
