using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//When the player manages to reach the "win flag" and beats the level, call the breed function
public class WinScript : MonoBehaviour
{
    public GeneticPlatformController breedPlatforms;
    public GeneticRocketSpeedController breedRockets;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "WinFlag")
        {
            breedPlatforms.BreedPlatforms();
            breedRockets.BreedRockets();

        }
    }
}
