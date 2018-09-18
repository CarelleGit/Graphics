using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float magVelocity;
    [Range(1,2)]
    public float timer;
    public CharacterController characterController;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                timer += Time.deltaTime;
                if (timer >= 2)
                {
                    timer = 2;
                }
                characterController.Move(transform.forward * (speed * timer) * Time.deltaTime);
            }
            else
            {
                characterController.Move(transform.forward * speed * Time.deltaTime);
                timer -= Time.deltaTime;
                if (timer <= 1)
                {
                    timer = 1;
                }
            }
        }


        if (Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                timer += Time.deltaTime;
                if (timer >= 2)
                {
                    timer = 2;
                }
                characterController.Move(transform.forward * (-speed * timer) * Time.deltaTime);
            }
            else
            {
                characterController.Move(transform.forward * -speed * Time.deltaTime);
                timer -= Time.deltaTime;
                if (timer <= 1)
                {
                    timer = 1;
                }
            }
        }


        if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                timer += Time.deltaTime;
                if (timer >= 2)
                {
                    timer = 2;
                }
                characterController.Move(transform.right * (-speed * timer) * Time.deltaTime);
            }
            else
            {
                characterController.Move(transform.right * -speed * Time.deltaTime);
                timer -= Time.deltaTime;
                if (timer <= 1)
                {
                    timer = 1;
                }
            }
        }


        if (Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                timer += Time.deltaTime;
                if (timer >= 2)
                {
                    timer = 2;
                }
                characterController.Move(transform.right * (speed * timer) * Time.deltaTime);
            }
            else
            {
                characterController.Move(transform.right * speed * Time.deltaTime);
                timer -= Time.deltaTime;
                if (timer <= 1)
                {
                    timer = 1;
                }
            }
        }
        magVelocity = speed * timer;
    }
}
