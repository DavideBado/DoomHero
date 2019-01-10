using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piattaforma : MonoBehaviour
{
    public float Speed = 0.65f;   

	// Update is called once per frame
	void FixedUpdate ()
    {
        transform.position = transform.position + new Vector3(0f, 0f, -Speed); 
    }
    
}
