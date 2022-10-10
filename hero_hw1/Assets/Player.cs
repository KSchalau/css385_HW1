using UnityEngine;
using UnityEngine.UI;
using TMPro;

/*
code used/referenced: space_to_shoot_2d, wasd_speed_direction_2d in github 100
*/

public class Player : MonoBehaviour {

    public float speed;
    public float rotateSpeed;

    private Rigidbody2D rb2d;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public Vector2 movement;
    private bool mouseAcvtive;
    private bool arrowActive;

    /*
    reference [2]: https://www.youtube.com/watch?v=LuAAzNDhVko
    */
    //text
    private string textValue;
    private int enemyTouched = 0;
    public TextMeshProUGUI textElement;

    //bullets
    private float bulletSpeed = 40f;
    private float cooldown = 0.2f;
    private float nextFire = 0f;

    void Start () {
        rb2d = GetComponent<Rigidbody2D> ();
    }
    
    void Update () {
        UpdateMotion();
        ProcessBulletSpawn();
    }

    /*
    reference [1]: https://gamedevbeginner.com/make-an-object-follow-the-mouse-in-unity-in-2d/
    */
    private void UpdateMotion() {

        if (arrowActive) {

            // Change Speed
            if (Input.GetKey(KeyCode.W)) {
                speed += 0.5f;
            } else if (Input.GetKey(KeyCode.S)) {
                speed -= 0.5f;
            }

            // Change direction
            if (Input.GetKey(KeyCode.A)) {
                transform.Rotate(0,0,rotateSpeed);
            }
            if (Input.GetKey(KeyCode.D)) {
                transform.Rotate(0,0,-1 * rotateSpeed);
            }
            rb2d.velocity = transform.up * speed;

            textValue = "HERO: Drive(M-key) TouchedEnemy(" + enemyTouched + ")";
            textElement.text = textValue;

        } else {
            //reference [1] code <start>
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;
            //reference [1] code <end>

            // Change direction
            if (Input.GetKey(KeyCode.A)) {
                transform.Rotate(0,0,rotateSpeed);
            }
            if (Input.GetKey(KeyCode.D)) {
                transform.Rotate(0,0,-1 * rotateSpeed);
            }
            rb2d.velocity = transform.up * speed;

            textValue = "HERO: Drive(mouse) TouchedEnemy(" + enemyTouched + ")";
            textElement.text = textValue;

        }

        if (Input.GetKey(KeyCode.M)) {

            if (!arrowActive) {
                arrowActive = true;
            } else {
                arrowActive = false;
            }
            
        }

    }

    void  OnTriggerEnter2D(Collider2D col) { 
        if (col.gameObject.tag.Equals("Enemy")) {
            enemyTouched++;
        }
    }

    void moveCharacter(Vector3 direction) {
        rb2d.AddForce(direction * speed);
    }
    
    private void ProcessBulletSpawn() {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire) {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D re = bullet.GetComponent<Rigidbody2D>();
            re.velocity = firePoint.up * bulletSpeed;
            nextFire = Time.time + cooldown;
        }
    }
}