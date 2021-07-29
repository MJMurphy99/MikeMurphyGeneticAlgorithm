using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DNA component of the Rocket Speed for the GA
public class RocketSpeedDNA : MonoBehaviour
{
    public float rocketSpeedDNA;
    public void Update()
    {
        transform.position += -transform.right * rocketSpeedDNA * Time.deltaTime;
    }
}
