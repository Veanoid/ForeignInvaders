﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour {

    public Vector3 force;

    public Owner owner;
    
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.Translate(force * Time.deltaTime);
	}

    void OnTriggerEnter(Collider collider)
    {
        Owned other = collider.gameObject.GetComponent<Owned>();
        if (other)
        {
            if (owner == other.owner)
                return;
        }
        Destroy(this.gameObject);
    }
}
