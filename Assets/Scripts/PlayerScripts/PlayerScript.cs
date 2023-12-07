using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject LaserShot;
    public GameObject LaserShotSmallRight;
    public GameObject LaserShotSmallLeft;
    public GameObject StarShipExplosion;

    public Transform LaserGunMain;
    public Transform LaserGunSmallRight;
    public Transform LaserGunSmallLeft;
    public float shotDelay;
    public float shotDelaySecondary;
    public float maneurspeed;
    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;
    Rigidbody player;
    float nextShotTime;
    float nextShotTimeSecondary;
    void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!GameControllerScript.instance.isStarted)
        {
            return;
        }
        var moveHor = Input.GetAxis("Horizontal");
        player.velocity = new Vector3(moveHor * maneurspeed, 0, speed);
        var clampedX = Mathf.Clamp(player.position.x, xMin, xMax);
        var clampedZ = Mathf.Clamp(player.position.z, zMin, zMax);
        player.position = new Vector3(clampedX, 0, clampedZ);
        player.rotation = Quaternion.Euler(tilt * player.velocity.z, 0, tilt * -player.velocity.x);

        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(LaserShot, LaserGunMain.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

        if (Time.time > nextShotTimeSecondary && Input.GetButton("Fire2")){
            Instantiate(LaserShotSmallRight, LaserGunSmallRight.position, Quaternion.Euler(0, 45, 0));
            Instantiate(LaserShotSmallLeft, LaserGunSmallLeft.position, Quaternion.Euler(0, -45, 0));
            nextShotTimeSecondary = Time.time + shotDelaySecondary;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyLSR")
        {
            GameControllerScript.instance.decreaseShield(1);
            Destroy(other.gameObject);
        }
        if (other.tag == "Enemy")
        {
            GameControllerScript.instance.decreaseShield(1);
            Destroy(other.gameObject);
            Instantiate(StarShipExplosion, other.transform.position, Quaternion.identity);
            GameControllerScript.instance.increaseScore(10);
        }
    }
}
