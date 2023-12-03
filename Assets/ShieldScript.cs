using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public GameObject shieldBoom;
    //public GameObject shieldPicked;
    public float rotationSpeed;
    public float speedMin, speedMax;
    Rigidbody shield;
    void Start()
    {
        shield = GetComponent<Rigidbody>();
        shield.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        shield.velocity = new Vector3(0, 0, -Random.Range(speedMin, speedMax));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Border")
        {
            return;
        }

        if (other.tag == "Player")
        {
            Destroy(gameObject);
            //Instantiate(shieldPicked, other.transform.position, Quaternion.identity);
            GCScript.instance.increaseShield(1);
            return;
        }
        Destroy(gameObject);
        Destroy(other.gameObject);

        Instantiate(shieldBoom, transform.position, Quaternion.identity);
    }
}
