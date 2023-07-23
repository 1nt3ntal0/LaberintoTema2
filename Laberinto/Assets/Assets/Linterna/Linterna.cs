
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linterna : MonoBehaviour
{
    public Light Luzlinterna;

    void Start()
    {
        
    }

    void Update()
    {
     	if (Input.GetButtonDown("Linterna"))
	    {
        	if (Luzlinterna.enabled == true)
			    Luzlinterna.enabled = false;
    	    else if (Luzlinterna.enabled == false)
			    Luzlinterna.enabled = true;
	    }
    }
}
