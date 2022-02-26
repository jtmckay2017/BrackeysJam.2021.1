using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class HighriseLevel : MonoBehaviour
{
    private static HighriseLevel _instance;

    public static HighriseLevel Instance { get { return _instance; } }

    public Image fadeImage;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeImage(true));
    }

    // Update is called once per frame
    void Update()
    {
        
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
