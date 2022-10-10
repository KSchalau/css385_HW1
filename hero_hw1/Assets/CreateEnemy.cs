using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemy : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    float timer = 2f;
    float enemyCount = 0f;

    private GameObject[] getCount;
    float count;

    // Update is called once per frame
    void Update() {
        //below from reference: https://answers.unity.com/questions/625683/how-can-i-count-the-number-of-instances-of-a-tagge.html
        getCount = GameObject.FindGameObjectsWithTag ("Enemy");
        count = getCount.Length;
        
        if (count < 10) {
            SpawnObject();
            enemyCount++;
        }

        timer += Time.deltaTime;
        if (timer >= 3) { 
            timer = 0f;
        }    
        
    }

    private void SpawnObject() {
        
        bool objSpawned = false;
        
        while (!objSpawned) {
            Vector3 objPosition = new Vector3(Random.Range(-150f, 150f), Random.Range(-80f, 80f), 0);
            
            // ensures new object is spawned far enough away
            if ((objPosition - transform.position).magnitude < 3) {
                continue;
            }
            else {
                objSpawned = true;
                Instantiate(enemy, objPosition, Quaternion.identity);
                //Destroy(Instantiate(enemy, objPosition, Quaternion.identity), 2.0f);
            }
            
        }
    }
}
