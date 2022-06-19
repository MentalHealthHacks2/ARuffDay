using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    public void GoToNextScene()
    {
        StartCoroutine(GoNextScene());
    }

    private IEnumerator GoNextScene()
    {
        //yield return new WaitForSeconds(2); // Wait a couple seconds
        Debug.Log("Next");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        yield return null;
    }
}
