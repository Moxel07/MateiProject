using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tras : MonoBehaviour
{
    public Transform cam;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        { 
            if(Physics.Raycast(cam.position, cam.forward,out hit))
            {

                Viata healthScript=hit.collider.gameObject.GetComponent<Viata>();
                if(healthScript!=null)
                healthScript.health -= 20;
            }
        }
        
    }
}
