using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Health;
    public Owner player;

    public float extent;
    public Transform center;

    public Transform bulletSpawn;
    public float m_speed;
    public GameObject bullet;
    public KeyCode shoot;
    public float bulletSpeed;
    public KeyCode MoveLeft;
    public KeyCode MoveRight;

    private Rigidbody person;

    // Use this for initialization
    void Start()
    {
        person = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = 0;// = Input.GetAxis("Vertical");

        if (Input.GetKey(MoveLeft))
        {
            moveHorizontal = 1;
        }
        if (Input.GetKey(MoveRight))
        {
            moveHorizontal = -1;
        }

        Vector3 movement = new Vector3(0, 0.0f, moveHorizontal);
        person.position += movement * m_speed * Time.deltaTime;

        Vector3 move = person.position;
        move.z = Mathf.Clamp(move.z, center.position.z - extent, center.position.z + extent);

        person.position = move;

        if (Input.GetKeyDown(shoot))
	    {
            GameObject temp = Instantiate(bullet, bulletSpawn.position, this.transform.localRotation);
            temp.GetComponent<Bullet>().force = bulletSpeed * bulletSpawn.forward;
            temp.GetComponent<Bullet>().owner = player;

        }
    }

    void OnTriggerEnter(Collider collider)
    {
       Bullet temp = collider.gameObject.GetComponent<Bullet>();
        if (temp)
        {
            Health -= 1;
        }
        if (Health <= 0)
        {
            // player dead
        }
    }



}
