using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject LazaShot;
    public GameObject sSBoom;

    public Transform LazGunMC;
    Transform playerTransform;

    public float shotDelay;
    public float laserSpeed;
    public float speed;
    public float tilt;
    public float xMin, xMax, zMin, zMax;
    Rigidbody playa;
    float nextShotTime;
    float xPos;

    void Start()
    {
        playa = GetComponent<Rigidbody>();
        xPos = playa.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (!GCScript.instance.isStarted)
        {
            return;
        }
        if (playa.transform.position.z <= -42)
        {
            speed = 0;
        }

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction2 = (playerTransform.position - playa.position).normalized;
        playa.transform.rotation = Quaternion.LookRotation(-direction2);

        float moveHor;
        if (xPos > 0)
        {
            moveHor = speed * -1;
        }
        else
        {
            moveHor = speed;
        }

        var moveVer = speed * -1;
        playa.velocity = new Vector3(moveHor, 0, moveVer) * speed;
        var clampedX = Mathf.Clamp(playa.position.x, xMin, xMax);
        var clampedZ = Mathf.Clamp(playa.position.z, zMin, zMax);
        playa.position = new Vector3(clampedX, 0, clampedZ);
        playa.rotation = Quaternion.Euler(tilt * playa.velocity.z, 0, tilt * -playa.velocity.x);

        if (Time.time > nextShotTime)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
            Vector3 direction = (playerTransform.position - LazGunMC.position).normalized;
            GameObject shot = Instantiate(LazaShot, LazGunMC.position, Quaternion.identity);
            Rigidbody shotRigidbody = shot.GetComponent<Rigidbody>();
            shotRigidbody.velocity = direction * laserSpeed;
            shotRigidbody.rotation = Quaternion.LookRotation(direction);
            nextShotTime = Time.time + shotDelay;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LSR")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(sSBoom, transform.position, Quaternion.identity);
            GCScript.instance.increaseScore(5);
        }
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(sSBoom, transform.position, Quaternion.identity);
            Instantiate(sSBoom, other.transform.position, Quaternion.identity);
            GCScript.instance.increaseScore(5);
        }
    }
}