using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] GameObject playa;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playa != null)
        {
            gameObject.transform.position = playa.transform.position;
        }
    }
}