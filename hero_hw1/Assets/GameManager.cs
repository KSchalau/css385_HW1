using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject exitScreen;

    void Start() {
        exitScreen.SetActive(false);
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
            exitScreen.SetActive(true);
        }

    }
}
