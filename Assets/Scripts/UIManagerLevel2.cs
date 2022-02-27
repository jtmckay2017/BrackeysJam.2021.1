using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIManagerLevel2 : MonoBehaviour
{
    public TextMeshProUGUI bodyText;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HighriseLevel.Instance.bodies.Count != HighriseLevel.Instance.bodyCountToWin)
        {
            bodyText.text = $"Employees reprimanded {HighriseLevel.Instance.bodies.Count} / {HighriseLevel.Instance.bodyCountToWin}";
        }
        else
        {
            bodyText.text = "";
        }
    }
}
