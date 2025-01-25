using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRFinderUI : MonoBehaviour
{
    public enum State { LogoAnimation, StartUI, FindUI, CompassUI, AddItemUI, DeleteUI };
    
    public State state = State.LogoAnimation;

    public GameObject StartUI;
    public GameObject FindUI;
    public GameObject CompassUI;
    public GameObject AddItemUI;
    public GameObject DeleteUI;
    public GameObject VirtualKeyboard;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void UpdateState()
    {
        StartUI.SetActive(state == State.StartUI);
        FindUI.SetActive(state == State.FindUI);
        CompassUI.SetActive(state == State.CompassUI);
        AddItemUI.SetActive(state == State.AddItemUI);
        DeleteUI.SetActive(state == State.DeleteUI);
        //VirtualKeyboard.SetActive(state == State.FindUI || state == State.AddItemUI);

    }

    public void GoToStartUI()
    {
        this.state = State.StartUI;
        UpdateState();
    }
    public void GoToFindUI()
    {
        this.state = State.FindUI;
        UpdateState();
    }

    public void GoToCompassUI()
    {
        this.state = State.CompassUI;
        UpdateState();
    }

    public void GoToAddItemUI()
    {
        this.state = State.AddItemUI;
        UpdateState();
    }
    public void GoToDeleteUI()
    {
        this.state = State.DeleteUI;
        UpdateState();
    }

    public void KeyboardCommitText(string text)
    {

    }
}
