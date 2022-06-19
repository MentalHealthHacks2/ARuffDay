using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Neighbour : MonoBehaviour
{
    public GameObject ownerComes;
    public GameObject help;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Next());
    }
    
    IEnumerator Next() {
        yield return new WaitForSeconds(2);
        ownerComes.gameObject.SetActive(true);
        StartCoroutine(OfferHelp());
    }

    IEnumerator OfferHelp() {
        yield return new WaitForSeconds(2);
        ownerComes.gameObject.SetActive(false);
        this.gameObject.SetActive(false);
        help.gameObject.SetActive(true);
        GoNextScene();
    }

    public void GoToNextScene()
    {
        StartCoroutine(GoNextScene());
    }

    private IEnumerator GoNextScene()
    {
        yield return new WaitForSeconds(2); // Wait a couple seconds
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        yield return null;
    }
}
