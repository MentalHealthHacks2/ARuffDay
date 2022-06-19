using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToFindingScene : MonoBehaviour
{
    void onGUI()
    {
        SceneManager.LoadScene("FindingDoggo",LoadSceneMode.Single);
    }
        
}
