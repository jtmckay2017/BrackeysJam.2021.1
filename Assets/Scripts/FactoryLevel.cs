using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FactoryLevel : MonoBehaviour
{
    public List<GameObject> papers = new List<GameObject>();
    public int paperCountToWin = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Paper")
        {
            foreach (GameObject paper in papers)
            {
                if (collision.gameObject.GetInstanceID() == paper.GetInstanceID()) return;
            }
            papers.Add(collision.gameObject);
            if (papers.Count == paperCountToWin)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}
