using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject asteroidExplosion;
    public GameObject shieldChargeProc;
    public float rotationSpeed;
    public float speedMin, speedMax;
    Rigidbody asteroid;
    void Start()
    {
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        asteroid.velocity = new Vector3(0, 0, -Random.Range(speedMin, speedMax));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border" || other.tag == "Emitter")
        {
            return;
        }
        AudioManagerScript.instance.PlaySFX(2);
        Destroy(gameObject);
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        

        if (other.tag == "Player")
        {
            GameControllerScript.instance.decreaseShield(1);
        }

        if (other.tag == "Enemy")
        {
            Instantiate(shieldChargeProc, other.transform.position, Quaternion.identity);
        }
        if (other.tag == "LSR")
        {
            Destroy(other.gameObject);
            GameControllerScript.instance.increaseScore(1);
        }
        if (other.tag == "EnemyLSR")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Asteroid")
        {
            Destroy(other.gameObject);
        }
    }


}