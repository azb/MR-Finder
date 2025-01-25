using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRFinderUI : MonoBehaviour
{
    public static MRFinderUI Instance;

    public enum State { LogoAnimation, Viewing, StartUI, FindUI, AddItemUI, DeleteUI, MovingItem };

    public State state = State.LogoAnimation;
    public State lastState = State.LogoAnimation;

    public GameObject StartUI;
    public GameObject FindUI;
    public GameObject AddItemUI;
    public GameObject DeleteUI;
    public GameObject ViewingUI;
    public GameObject VirtualKeyboard;

    public FindArrow arrow;

    HoverInFrontOfPlayer hover;
    LookAtCamera look;

    public Item selectedItem;

    bool alreadyPressed;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        hover = GetComponent<HoverInFrontOfPlayer>();
        look = GetComponent<LookAtCamera>();
        UpdateState();
    }

    public void UpdateStateDelayed(State newState)
    {
        if (!alreadyPressed)
        {
            Invoke("UpdateState", .2f);
            alreadyPressed = true;
            state = newState;
        }
    }

    // Update is called once per frame
    void UpdateState()
    {
        StartUI.SetActive(state == State.StartUI);
        FindUI.SetActive(state == State.FindUI);
        AddItemUI.SetActive(state == State.AddItemUI);
        DeleteUI.SetActive(state == State.DeleteUI);
        ViewingUI.SetActive(state == State.Viewing);
        VirtualKeyboard.SetActive(state == State.FindUI || state == State.AddItemUI);
        alreadyPressed = false;
        hover.enabled = !VirtualKeyboard.activeSelf;
        look.enabled = !VirtualKeyboard.activeSelf;
    }

    public void GoToStartUI()
    {
        Debug.Log("GoToStartUI");
        UpdateStateDelayed(State.StartUI);
    }

    public void GoToFindUI()
    {
        Debug.Log("GoToFindUI");
        UpdateStateDelayed(State.FindUI);
    }

    public void GoToAddItemUI()
    {
        Debug.Log("GoToAddItemUI");
        UpdateStateDelayed(State.AddItemUI);
    }
    public void GoToDeleteUI()
    {
        Debug.Log("GoToDeleteUI");
        UpdateStateDelayed(State.DeleteUI);
    }

    public void ToggleMenu()
    {
        if (state == State.Viewing)
        {
            UpdateStateDelayed(State.StartUI);
        }
        else
        {
            UpdateStateDelayed(State.Viewing);
        }
    }

    public void SaveItem()
    {
        Debug.Log("GoToStartUI");
        UpdateStateDelayed(State.StartUI);
    }

    public void KeyboardCommitText(string text)
    {

    }

    public void OnGrabItem()
    {
        Debug.Log("OnGrabItem");
        lastState = state;
        state = State.MovingItem;
        UpdateState();
    }   
    
    public void OnReleaseItem()
    {
        Debug.Log("OnReleaseItem lastState = "+ lastState);
        //state = lastState;
        UpdateStateDelayed(lastState);
    }

    private void Update()
    {
        //if (OVRInput.GetDown(OVRInput.Button.Start))
        if (OVRInput.Get(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.LTouch))
        {
            if (state == State.Viewing)
            {
                state = lastState;
            }
            else
            {
                state = State.Viewing;
            }
        }
    }
}
