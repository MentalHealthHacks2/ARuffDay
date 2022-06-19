using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdviceScene : MonoBehaviour
{   
    
    void OnGUI()
    {
        //This displays a Button on the screen at position (20,30), width 150 and height 50. The button’s text reads the last parameter. Press this for the SceneManager to load the Scene.
        //if (GUI.Button(new Rect(537, 56, 150, 30), "Other Scene Single"))
        {
            //The SceneManager loads your new Scene as a single Scene (not overlapping). This is Single mode.
            SceneManager.LoadScene("EndingScene", LoadSceneMode.Single);
        }

      
    }
}
    //public void onEnable()
    //{
        //Only specifying the sceneName or sceneBuildIndex will load the Scene with the Single mode
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    //}
    

