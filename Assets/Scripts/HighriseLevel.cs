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

    public List<GameObject> bodies = new List<GameObject>();
    public int bodyCountToWin = 8;

    public GameObject speaker;
    public AudioClip speakerWinSound;
    public Animator cageAnimator;
    public AudioClip failedPasswordSound;

    private int currentKeyIndex = 0;
    private int[] password = { 5, 2, 4, 1, 3 };
    private bool failed = false;
    private bool passedKeyCodeTest = false;

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

    public void AddCode(int number)
    {
        if (passedKeyCodeTest)
        {
            return;
        }

        if (number != password[currentKeyIndex])
        {
            failed = true;
        }
   
        currentKeyIndex += 1;

        if (currentKeyIndex >= password.Length && !failed)
        {
            AudioSource.PlayClipAtPoint(speakerWinSound, speaker.transform.position);
            cageAnimator.enabled = true;
        } else if (currentKeyIndex >= password.Length && failed)
        {
            AudioSource.PlayClipAtPoint(failedPasswordSound, speaker.transform.position);
            currentKeyIndex = 0;
            failed = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeImage(true));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddBody(GameObject body)
    {
        foreach (GameObject paper in bodies)
        {
            if (body.gameObject.GetInstanceID() == paper.GetInstanceID()) return;
        }
        bodies.Add(body.gameObject);
        body.gameObject.SetActive(false);
        if (bodies.Count == bodyCountToWin)
        {
            StartCoroutine(ChangeLevel());
        }
    }

    IEnumerator ChangeLevel()
    {
        yield return StartCoroutine(FadeImage(false));
        SceneManager.LoadScene(2);
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
