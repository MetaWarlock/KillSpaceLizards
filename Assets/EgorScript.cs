using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EgorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject egorBoom;
    public GameObject sSBoom;
    public float rotationSpeed;
    public float speedMin, speedMax;
    Rigidbody egor;
    void Start()
    {
        egor = GetComponent<Rigidbody>();
        egor.angularVelocity = Random.insideUnitSphere * rotationSpeed;
        egor.velocity = new Vector3(0, 0, -Random.Range(speedMin, speedMax));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Border")
        {
            return;
        }

        Destroy(gameObject);
        Instantiate(egorBoom, transform.position, Quaternion.identity);

        if (other.tag == "Player")
        {
            GCScript.instance.decreaseShield(1);
            return;
        }

        Destroy(other.gameObject);
        

        if (other.tag == "Enemy")
        {
            Instantiate(sSBoom, other.transform.position, Quaternion.identity);
            GCScript.instance.increaseScore(5);
        }
        if (other.tag == "LSR")
        {
            GCScript.instance.increaseScore(1);
        }
    }


}