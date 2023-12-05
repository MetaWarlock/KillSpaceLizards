using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSREnemy : MonoBehaviour
{
    private void Start()
    {
        AudioManagerScript.instance.PlaySFX(1);
    }
}
