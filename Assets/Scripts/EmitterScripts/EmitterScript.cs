using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidEmitterScript : MonoBehaviour
{
    public GameObject asteroid, asteroid2, asteroid3;
    public float minDelay, maxDelay;

    float nextLaunchTime;

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.instance.isStarted)
        {
            return;
        }
        if(Time.time > nextLaunchTime)
        {
            var posY = 0;
            var posZ = transform.position.z;
            var posX = Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
            var realEgor = Random.Range(1, 4);
            if (realEgor == 1)
            {
                Instantiate(asteroid, new Vector3(posX, posY, posZ), Quaternion.identity);
            }
            if (realEgor == 2)
            {
                Instantiate(asteroid2, new Vector3(posX, posY, posZ), Quaternion.identity);
            }
            if (realEgor == 3)
            {
                Instantiate(asteroid3, new Vector3(posX, posY, posZ), Quaternion.identity);
            }
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
