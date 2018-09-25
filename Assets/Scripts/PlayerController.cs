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
    private bool unlockedCursor = false;
    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer = Mathf.Clamp(timer, 1f, 2f);

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            switch (Cursor.lockState)
            {
                case CursorLockMode.Locked:
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
                case CursorLockMode.None:
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    break;
            }
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
                timer += Time.deltaTime;
                characterController.Move(transform.forward * (speed * timer) * Time.deltaTime);
            }
            else
            {
                blendSpeed = Mathf.Clamp(blendSpeed, 0, .2f);
                blendSpeed += .01f;
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
