using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayaScript : MonoBehaviour
{
    public GameObject LazaShot;
    public GameObject LazaShotSmallRight;
    public GameObject LazaShotSmallLeft;
    public GameObject sSBoom;

    public Transform LazGunMC;
    public Transform LazGun;
    public Transform LazGun2;
    public float shotDelay;
    public float shotDelaySecondary;
    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;
    Rigidbody playa;
    float nextShotTime;
    float nextShotTimeSecondary;
    // Start is called before the first frame update
    void Start()
    {
        playa = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!GCScript.instance.isStarted)
        {
            return;
        }
        var moveHor = Input.GetAxis("Horizontal");
        var moveVer = Input.GetAxis("Vertical");
        playa.velocity = new Vector3(moveHor, 0, moveVer) * speed;
        var clampedX = Mathf.Clamp(playa.position.x, xMin, xMax);
        var clampedZ = Mathf.Clamp(playa.position.z, zMin, zMax);
        playa.position = new Vector3(clampedX, 0, clampedZ);
        playa.rotation = Quaternion.Euler(tilt * playa.velocity.z, 0, tilt * -playa.velocity.x);

        if (Time.time > nextShotTime && Input.GetButton("Fire1"))
        {
            Instantiate(LazaShot, LazGunMC.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }

        if (Time.time > nextShotTimeSecondary && Input.GetButton("Fire2")){
            Instantiate(LazaShotSmallRight, LazGun.position, Quaternion.Euler(0, 45, 0));
            Instantiate(LazaShotSmallLeft, LazGun2.position, Quaternion.Euler(0, -45, 0));
            nextShotTimeSecondary = Time.time + shotDelaySecondary;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EnemyLSR")
        {
            GCScript.instance.decreaseShield(1);
            Destroy(other.gameObject);
        }
        if (other.tag == "Enemy")
        {
            GCScript.instance.decreaseShield(1);
            Destroy(other.gameObject);
            Instantiate(sSBoom, other.transform.position, Quaternion.identity);
            GCScript.instance.increaseScore(10);
        }
    }
}
