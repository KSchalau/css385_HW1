using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
referencing: https://www.youtube.com/watch?v=LuAAzNDhVko
*/

public class ScreenMessage : MonoBehaviour {

    private string textValue;
    private string textValue2;
    public TextMeshProUGUI textElement;
    public TextMeshProUGUI textElement2;

    private GameObject[] getCountEgg;
    private GameObject[] getCountEnemy;
    private int eggCount;
    private int enemyCount;
    public static int enemyUpdate;

    // Start is called before the first frame update
    void Start() {
        //textValue = "Hello World";
        //textElement.text = textValue;
        //enemyUpdate -= 10;
    }

    // Update is called once per frame
    void Update() {
        getCountEgg = GameObject.FindGameObjectsWithTag ("Bullet");
        eggCount = getCountEgg.Length;

        getCountEnemy = GameObject.FindGameObjectsWithTag ("Enemy");
        enemyCount = getCountEnemy.Length;

        textValue = "EGG: OnScreen(" + eggCount + ")";
        textElement.text = textValue;
        /*
        if (enemyCount < 10) {
            enemyUpdate++;
        }
        */
        textValue2 = "ENEMY: Count(10) Destroyed(" + enemyUpdate + ")";
        textElement2.text = textValue2;
    }
}
