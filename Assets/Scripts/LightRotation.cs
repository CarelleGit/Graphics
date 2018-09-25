using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotation : MonoBehaviour
{
    Quaternion night;
    Quaternion day;
    public ParticleSystem rotatingParticles;
    // Use this for initialization
    void Start()
    {
        night = Quaternion.Euler(-29, -2447, -144);
        day = Quaternion.Euler(0, -2116, -135);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Mouse0))//Left Click == Night
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, night, Time.deltaTime * 100);
            rotatingParticles.Play();
        }
        else if(Input.GetKey(KeyCode.Mouse1))//Right Click == Day
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, day, Time.deltaTime * 100);
            rotatingParticles.Stop();
        }
    }
}
