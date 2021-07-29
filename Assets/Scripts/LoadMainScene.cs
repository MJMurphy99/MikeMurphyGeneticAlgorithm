using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Returns the player to the game scene when winning
//Currently not in use
public class LoadMainScene : MonoBehaviour
{
    public void LoadMainSceneButton()
    {
        SceneManager.LoadScene(0);
    }
}
