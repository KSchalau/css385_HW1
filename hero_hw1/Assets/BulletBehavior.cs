using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
referencing: space_to_2d_... from github 100,
https://www.youtube.com/watch?v=LMOGPN5p4NU 
*/
public class BulletBehavior : MonoBehaviour
{

    public Collider2D objectToCollide;

    void Update() {
        //getCount = GameObject.FindGameObjectsWithTag ("Bullet");
        //count = getCount.Length;
    }

    //Physics.IgnoreCollision(bullet.GetComponent<Collider>(), GetComponent<Collider>());

    void  OnTriggerEnter2D(Collider2D col) { 
        if (col.gameObject.tag.Equals("Enemy")) {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible() { 
        Destroy(gameObject); 
    }
}
