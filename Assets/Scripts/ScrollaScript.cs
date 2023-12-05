using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollaScript : MonoBehaviour
{
    public float speed;
    Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        var offset = Mathf.Repeat(Time.time * speed, 150);
        transform.position = startPos + Vector3.back * offset;
    }
}
