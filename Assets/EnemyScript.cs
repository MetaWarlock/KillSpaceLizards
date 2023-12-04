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
    Rigidbody enemy;
    float nextShotTime;
    float xPos;

    void Start()
    {
        enemy = GetComponent<Rigidbody>();
        xPos = enemy.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        if (!GCScript.instance.isStarted)
        {
            return;
        }
        if (enemy.transform.position.z <= -42)
        {
            speed = 0;
        }

        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 direction2 = (playerTransform.position - enemy.position).normalized;
        enemy.transform.rotation = Quaternion.LookRotation(-direction2);

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
        enemy.velocity = new Vector3(moveHor, 0, moveVer) * speed;
        var clampedX = Mathf.Clamp(enemy.position.x, xMin, xMax);
        var clampedZ = Mathf.Clamp(enemy.position.z, zMin, zMax);
        enemy.position = new Vector3(clampedX, 0, clampedZ);
        enemy.rotation = Quaternion.Euler(tilt * enemy.velocity.z, 0, tilt * -enemy.velocity.x);

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