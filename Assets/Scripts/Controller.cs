using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField]
    private Animator playerAnim;

    public float currentSpeed = 10;
    public float maxSpeed = 10;
    public float minSpeed = 3;

    [SerializeField]
    private float currentBlend = 0.0f;
    private float maxBlending = 1.0f;
    private float minBlending = 0.0f;

    // Use this for initialization
    void Start()
    {
        currentSpeed = minSpeed;
        playerAnim.SetTrigger("Walking");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * currentSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * currentSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            //if(currentBlend >= minBlending)
            //{
            //    currentBlend -= .2f;
            //}
            if (currentBlend >= minBlending && currentBlend <= maxBlending)
            {
                currentBlend += .2f;
                playerAnim.SetFloat("WalkToRun", currentBlend);
            }
            if (currentBlend >= 0.5f && !Input.GetKey(KeyCode.LeftShift))
            {
                currentBlend = 0.335f;
                playerAnim.SetFloat("WalkToRun", currentBlend);
            }

        }
        else
        {
            if (currentBlend >= minBlending)
            {
                currentBlend -= .02f;
            }
            //if (currentBlend <= minBlending)
            //{
            currentSpeed = 0;
            //playerAnim.SetFloat("WalkToRun", minBlending);
            //}


        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentBlend += .02f;
            currentSpeed += .02f;
            playerAnim.SetFloat("WalkToRun", currentBlend);
            //if (currentSpeed >= maxSpeed || currentBlend >= maxBlending)
            //{
                currentSpeed = maxSpeed;
                currentBlend = maxBlending;
            //}
        }
    }
}
