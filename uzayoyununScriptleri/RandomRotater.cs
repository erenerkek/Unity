using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomRotater : MonoBehaviour
{
    Rigidbody physic;

    private void Start()
    {
        physic = GetComponent<Rigidbody>();


        physic.angularVelocity = Random.insideUnitSphere;
    }
}
