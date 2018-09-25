using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float magVelocity;
    //[Range(1,2)]
    public float timer;
    public float blendSpeed;
    public CharacterController characterController;
    public Animator playerAnim;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = Mathf.Clamp(timer, 1f, 2f);

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        playerAnim.SetFloat("Speed", blendSpeed);
        if (Input.GetKey(KeyCode.W))
        {
            timer -= Time.deltaTime;
            characterController.Move(transform.forward * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.LeftShift))
            {
                blendSpeed = Mathf.Clamp(blendSpeed, .2f, 1f);
                blendSpeed += .01f;
                // playerAnim.SetFloat("Speed", blendSpeed);
                timer += Time.deltaTime;
                characterController.Move(transform.forward * (speed * timer) * Time.deltaTime);
            }
            else
            {
                blendSpeed = Mathf.Clamp(blendSpeed, 0, .2f);
                blendSpeed += .01f;
                //playerAnim.SetFloat("Speed", blendSpeed);
            }
        }
       

        if (Input.GetKey(KeyCode.S))
        {
            playerAnim.SetFloat("Speed", -.2f);

            characterController.Move(transform.forward * -speed * Time.deltaTime);
            timer -= Time.deltaTime;
        }

        if (Input.anyKey == false)
        {
            blendSpeed = Mathf.Clamp(blendSpeed, 0, .2f);
            blendSpeed -= .01f;
        }

        magVelocity = speed * timer;
    }
}
