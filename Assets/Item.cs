using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    MRFinderUI mrFinderUI;
    // Start is called before the first frame update
    void Start()
    {
        mrFinderUI = FindObjectOfType<MRFinderUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnGrab()
    {
        mrFinderUI.OnGrabItem();
    }

    public void OnRelease()
    {
        mrFinderUI.OnReleaseItem();
    }
}
