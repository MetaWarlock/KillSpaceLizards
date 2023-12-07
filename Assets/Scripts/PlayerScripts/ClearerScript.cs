using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearerScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float zCorrection;
    private void Update()
    {
        if (player)
        {
            transform.position = new Vector3(0, 0, player.position.z - zCorrection);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" || other.tag == "Asteroid" || other.tag == "EnemyLSR") {
            Destroy(other.gameObject);
        }
    }
}
