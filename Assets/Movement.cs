using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cam;
    public float maxSpeed;
    public float acc = 0;
    public float jumpHeight;
    public LayerMask lm;
    bool crouched = false;
    Vector3 playerVelocity;
    CharacterController control;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        control = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        Vector3 axisInput = new Vector3(hor, 0, ver);
        

        bool grounded = Physics.CheckSphere(transform.position - transform.up * control.height  * 0.3f,0.5f,lm);



        if (grounded) 
        {
            if (playerVelocity.y < 0)
            {
                playerVelocity.y = -4f;
            }
            axisInput = Vector3.ClampMagnitude(axisInput, 1);
            axisInput = Quaternion.FromToRotation(Vector3.forward, transform.forward) * axisInput;
            playerVelocity = axisInput * maxSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                transform.position += Vector3.up * 0.5f;
                playerVelocity.y = Mathf.Sqrt(jumpHeight * -3 * -10);

            }
        }

        playerVelocity.y += -10 * Time.deltaTime;

        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        cam.transform.Rotate(new Vector3(-my, 0, 0), Space.Self);
        transform.Rotate(new Vector3(0, mx, 0), Space.World);

        if ((control.collisionFlags & CollisionFlags.Above) != 0)
        {
            playerVelocity.y -= 60 * Time.deltaTime;

        }
        control.Move(playerVelocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 20;
        }
        else
            maxSpeed = 9;
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouched = !crouched;
            if (crouched == true)
            {
                maxSpeed = 3;
            }
            if(crouched == false)
            {
                maxSpeed = 9;
            }
        }
        if (crouched == true)
        {
            control.height = Mathf.Lerp(control.height, 1, 0.4f);

        }
        if (crouched == false)
        {
            control.height = Mathf.Lerp(control.height, 2, 0.4f);
        }

    }
}
