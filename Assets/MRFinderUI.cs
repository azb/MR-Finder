using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRFinderUI : MonoBehaviour
{
    public enum State { LogoAnimation, StartUI, FindUI, SetupUI, DeleteUI };
    
    public State state = State.LogoAnimation;

    public GameObject StartUI;
    public GameObject FindUI;
    public GameObject SetupUI;
    public GameObject DeleteUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
