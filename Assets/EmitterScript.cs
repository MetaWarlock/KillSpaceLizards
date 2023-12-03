using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject egor, egor2, egor3;
    public float minDelay, maxDelay;

    float nextLaunchTime;

    // Update is called once per frame
    void Update()
    {
        if (!GCScript.instance.isStarted)
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
