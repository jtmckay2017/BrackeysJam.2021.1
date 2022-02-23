using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterinteractabke : MonoBehaviour
{
    [SerializeField] GameObject forklift;
    [SerializeField] GameObject pallet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            forklift.GetComponent<forklift>().playAnim();
            pallet.GetComponent<liftedpallet>().playliftedAnim();
        }
    }
}
