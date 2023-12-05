using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EgorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject egorBoom;
    public GameObject shieldChargeProc;
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
        if (other.tag == "Border" || other.tag == "Emitter")
        {
            return;
        }
        AudioManagerScript.instance.PlaySFX(2);
        Destroy(gameObject);
        Instantiate(egorBoom, transform.position, Quaternion.identity);
        

        if (other.tag == "Player")
        {
            GCScript.instance.decreaseShield(1);
        }

        if (other.tag == "Enemy")
        {
            Instantiate(shieldChargeProc, other.transform.position, Quaternion.identity);
        }
        if (other.tag == "LSR")
        {
            Destroy(other.gameObject);
            GCScript.instance.increaseScore(1);
        }
        if (other.tag == "EnemyLSR")
        {
            Destroy(other.gameObject);
        }
        if (other.tag == "Egor")
        {
            Destroy(other.gameObject);
        }
    }


}