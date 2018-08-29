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
    private Rigidbody rigidbody;
    // Use this for initialization
    void Start()
    {
        currentSpeed = minSpeed;
    }



    float x = 0;
    float z = 0;


    // Update is called once per frame
    void Update()
    {
        //sets player speed to 0 if no input is detected
        if ((Input.GetAxis("Horizontal") == 0) && (Input.GetAxis("Vertical") == 0))
        {
            x = 0;
            z = 0;
        }


        //input to movement handler
        Vector3 movement = new Vector3(x, 0.0f, z);

        //moyion handler
        rigidbody.MovePosition(transform.position + movement);



        playerAnim.SetFloat("WalkToRun", currentSpeed);

        //regular walking controller
        if (Input.GetKey(KeyCode.W))
        {
            //applies speed & player input to character object for walking
            x = Input.GetAxis("Horizontal") * Time.deltaTime * currentSpeed;
            z = Input.GetAxis("Vertical") * Time.deltaTime * currentSpeed;


            if (currentSpeed >= 2 && !Input.GetKey(KeyCode.LeftShift))
            {
                //regulates walking speed
                if (currentSpeed <= minSpeed)
                {
                    currentSpeed = minSpeed;
                }
                if (currentSpeed >= maxSpeed)
                {
                    currentSpeed = maxSpeed;
                }

                currentSpeed -= Time.deltaTime * 5;
            }
            else
            {
                currentSpeed += Time.deltaTime * 10;


                //regulates walking speed
                if (currentSpeed <= minSpeed * 2)
                {
                    currentSpeed = minSpeed * 2;
                }
                if (currentSpeed >= maxSpeed * 2)
                {
                    currentSpeed = maxSpeed * 2;
                }

            }

        }


        //backwards walking controller
        if (Input.GetKey(KeyCode.S))
        {
            //applies speed & player input to character object for walking in reverse
            x = Input.GetAxis("Horizontal") * Time.deltaTime * -currentSpeed;
            z = Input.GetAxis("Vertical") * Time.deltaTime * -currentSpeed;

            playerAnim.SetTrigger("WalkingBack");


            //regulates reverse speed
            if (currentSpeed <= -minSpeed)
            {
                currentSpeed = -minSpeed;
            }
            if (currentSpeed >= -maxSpeed)
            {
                currentSpeed = -maxSpeed;
            }
            if (currentSpeed >= 2 && !Input.GetKey(KeyCode.LeftShift))
            {

                currentSpeed -= -Time.deltaTime * 5;
            }
            else
            {
                currentSpeed += -Time.deltaTime * 10;
            }

        }
        else
        {
            playerAnim.SetTrigger("Walking");


        }

        //
        currentSpeed -= Time.deltaTime * 5;


    }
}
