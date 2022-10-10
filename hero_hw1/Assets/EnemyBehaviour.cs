using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    double currentTransparency = 1d;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D col) { 
        if (col.gameObject.tag.Equals("Hero")) {
            Destroy(gameObject);
            ScreenMessage.enemyUpdate++;
        }
        
        if (col.gameObject.tag.Equals("Bullet")) {
            currentTransparency = currentTransparency * 0.8;
            gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1.0f, 1.0f, 1.0f, (float) currentTransparency);

            if (currentTransparency < 0.5f) {
                Destroy(gameObject);
                ScreenMessage.enemyUpdate++;
            }
        }
    }

    void OnBecameInvisible() { 
        Destroy(gameObject); 
    }

}
