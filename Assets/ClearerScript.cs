using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearerScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Egor" || other.tag == "EnemyLSR") {
            Destroy(other.gameObject);
        }
    }
}
