using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class FactoryLevel : MonoBehaviour
{
    public List<GameObject> papers = new List<GameObject>();
    public int paperCountToWin = 3;

    private static FactoryLevel _instance;

    public static FactoryLevel Instance { get { return _instance; } }

    public Image fadeImage;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void Start()
    {
        StartCoroutine(FadeImage(true));
    }


    public void AddPaper(Paper addedPaper)
    {
        foreach (GameObject paper in papers)
        {
            if (addedPaper.gameObject.GetInstanceID() == paper.GetInstanceID()) return;
        }
        papers.Add(addedPaper.gameObject);
        addedPaper.gameObject.SetActive(false);
 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (papers.Count >= paperCountToWin)
        {
            StartCoroutine(ChangeLevel());
        }
    }

    IEnumerator ChangeLevel()
    {
        yield return StartCoroutine(FadeImage(false));
        SceneManager.LoadScene(3);
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 3; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                fadeImage.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 3; i += Time.deltaTime)
            {
                // set color with i as alpha
                fadeImage.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }
}
