using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FactoryLevel : MonoBehaviour
{
    public List<GameObject> papers = new List<GameObject>();
    public int paperCountToWin = 3;

    private static FactoryLevel _instance;

    public static FactoryLevel Instance { get { return _instance; } }


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

    public void AddPaper(Paper addedPaper)
    {
        foreach (GameObject paper in papers)
        {
            if (addedPaper.gameObject.GetInstanceID() == paper.GetInstanceID()) return;
        }
        papers.Add(addedPaper.gameObject);
        addedPaper.gameObject.SetActive(false);
        if (papers.Count == paperCountToWin)
        {
            SceneManager.LoadScene(3);
        }
    }
}
