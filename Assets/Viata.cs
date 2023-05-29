using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Viata : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
    }
}
