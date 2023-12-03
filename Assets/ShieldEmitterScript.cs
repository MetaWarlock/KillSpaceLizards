using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEmitterScript : MonoBehaviour
{
    public GameObject shield;
    public float minDelay, maxDelay;

    float nextLaunchTime;

    void Update()
    {
        if (!GCScript.instance.isStarted)
        {
            return;
        }
        if (Time.time > nextLaunchTime)
        {
            var posY = 0;
            var posZ = transform.position.z;
            var posX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            Instantiate(shield, new Vector3(posX, posY, posZ), Quaternion.identity);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
