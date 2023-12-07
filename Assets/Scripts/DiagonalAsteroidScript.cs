using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalAsteroidScript : MonoBehaviour
{
    public GameObject asteroidExplosion;
    public GameObject shieldChargeProc;
    public float rotationSpeed;
    public float speedMin, speedMax;
    float trueXSpeed;
    Rigidbody asteroid;
    void Start()
    {
        asteroid = GetComponent<Rigidbody>();
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        if (gameObject.transform.position.x >= 0)
        {
            trueXSpeed = -Random.Range(speedMin, speedMax);
        }
        else
        {
            trueXSpeed = Random.Range(speedMin, speedMax);
        }

        asteroid.velocity = new Vector3(trueXSpeed, 0, -Random.Range(speedMin, speedMax));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border" || other.tag == "Emitter")
        {
            return;
        }

        Destroy(gameObject);
        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
        AudioManagerScript.instance.PlaySFX(2);

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
