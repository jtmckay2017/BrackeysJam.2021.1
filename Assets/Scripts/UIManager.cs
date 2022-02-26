using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI paperText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FactoryLevel.Instance.papers.Count != FactoryLevel.Instance.paperCountToWin)
        {
            paperText.text = $"Papers Collected {FactoryLevel.Instance.papers.Count} / {FactoryLevel.Instance.paperCountToWin}";
        } else
        {
            paperText.text = "Time to get in the trailer and leave...";
        }
    }


}
