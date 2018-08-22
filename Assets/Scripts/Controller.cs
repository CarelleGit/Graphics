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
    // Use this for initialization
    void Start()
    {
        currentSpeed = minSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * Time.deltaTime * currentSpeed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * currentSpeed;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        playerAnim.SetFloat("WalkToRun", currentSpeed);
        if (currentSpeed <= minSpeed)
        {
            currentSpeed = minSpeed;
        }
        if (currentSpeed >= maxSpeed)
        {
            currentSpeed = maxSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (currentSpeed >= 2 && !Input.GetKey(KeyCode.LeftShift))
            {
                //currentSpeed = maxSpeed / 2;
                currentSpeed -= Time.deltaTime * 5;
            }
            else
            {
                currentSpeed += Time.deltaTime * 10;
            }

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed += Time.deltaTime * 10;
        }
        else
        {
            currentSpeed -= Time.deltaTime * 5;
        }
    }
}
