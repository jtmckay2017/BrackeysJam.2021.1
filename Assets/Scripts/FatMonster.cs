using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatMonster : MonoBehaviour
{
    public AudioClip eatSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HumanMeat")
        {
            AudioSource.PlayClipAtPoint(eatSound, transform.position);
            GameObject.Destroy(other.gameObject);
        }
    }
}
