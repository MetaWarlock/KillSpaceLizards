using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiagonalEmitterScript : MonoBehaviour
{
    public GameObject egor, egor2, egor3;
    public float minDelay, maxDelay;

    float nextLaunchTime;

    // Update is called once per frame
    void Update()
    {
        if (!GameControllerScript.instance.isStarted)
        {
            return;
        }
        if (Time.time > nextLaunchTime)
        {
            var posY = 0;
            var posZ =  Random.Range(-transform.localScale.z / 2 +transform.position.z , transform.localScale.z / 2 + transform.position.z);
            var posX = transform.position.x;
            var realEgor = Random.Range(1, 4);
            if (realEgor == 1)
            {
                Instantiate(egor, new Vector3(posX, posY, posZ), Quaternion.identity);
            }
            if (realEgor == 2)
            {
                Instantiate(egor2, new Vector3(posX, posY, posZ), Quaternion.identity);
            }
            if (realEgor == 3)
            {
                Instantiate(egor3, new Vector3(posX, posY, posZ), Quaternion.identity);
            }
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}
