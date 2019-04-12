using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shields : MonoBehaviour {

    [Range(1, 2)]
    public float shrink;

    private int Health = 10;

    void OnCollisionEnter(Collision collision)
    {
        Bullet temp = collision.collider.gameObject.GetComponent<Bullet>();
        if (this.GetComponent<Owned>().owner != temp.owner)
        {
            if (temp)
            {
                Health -= 1;
            }
            if (Health == 8 || Health == 4)
            {
                transform.localScale /= shrink;
            }

            if (Health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
