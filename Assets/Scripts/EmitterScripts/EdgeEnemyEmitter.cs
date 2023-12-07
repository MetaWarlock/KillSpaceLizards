using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeEnemyEmitter : MonoBehaviour
{
    public GameObject enemy;
    public float minDelay, maxDelay;

    float nextLaunchTime;

    void Update()
    {
        if (!GameControllerScript.instance.isStarted)
        {
            return;
        }
        if (Time.time > nextLaunchTime)
        {
            var posY = 0;
            var posZ = Random.Range(-transform.localScale.z / 2 + transform.position.z, transform.localScale.z / 2 + transform.position.z);
            var posX =  transform.position.x;
            Instantiate(enemy, new Vector3(posX, posY, posZ), Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }

}
