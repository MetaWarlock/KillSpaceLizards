using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearerScript : MonoBehaviour
{
    [SerializeField] Transform playa;
    private void Update()
    {
        if (playa)
        {
            transform.position = new Vector3(0, 0, playa.position.z - 25);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Egor" || other.tag == "EnemyLSR") {
            Destroy(other.gameObject);
        }
    }
}
