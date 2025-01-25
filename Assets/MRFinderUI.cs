using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MRFinderUI : MonoBehaviour
{
    public static MRFinderUI Instance;

    public enum State
    {
        LogoAnimation, Viewing, StartUI,
        FindUI, AddItemUI, DeleteUI,
        MovingItem, EditItemUI, RenameItemUI,
        CompassUI
    };

    public State state = State.LogoAnimation;
    public State lastState = State.LogoAnimation;

    public GameObject StartUI;
    public GameObject FindUI;
    public GameObject AddItemUI;
    public GameObject DeleteUI;
    public GameObject EditItemUI;
    public GameObject RenameItemUI;
    public GameObject ViewingUI;
    public GameObject CompassUI;
    public GameObject MenuButtonUI;
    public GameObject VirtualKeyboard;

    public FindArrow arrow;

    HoverInFrontOfPlayer hover;
    LookAtCamera look;

    public Item selectedItem;

    bool alreadyPressed;

    public GameObject ItemPrefab;

    ButtonFilter buttonFilter;

    private void Awake()
    {
        Instance = this;
        buttonFilter = FindObjectOfType<ButtonFilter>();
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
        EditItemUI.SetActive(state == State.EditItemUI);
        RenameItemUI.SetActive(state == State.RenameItemUI);
        CompassUI.SetActive(state == State.CompassUI);
        MenuButtonUI.SetActive(state != State.MovingItem);
        VirtualKeyboard.SetActive(state == State.FindUI || state == State.AddItemUI || state == State.RenameItemUI);
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
        GameObject newObj = Instantiate(
            ItemPrefab,
            Camera.main.transform.position + Camera.main.transform.forward * .5f,
            Quaternion.identity
        );

        this.selectedItem = newObj.GetComponent<Item>();
        Debug.Log("GoToAddItemUI");
        UpdateStateDelayed(State.AddItemUI);
    }
    public void GoToDeleteUI()
    {
        Debug.Log("GoToDeleteUI");
        UpdateStateDelayed(State.DeleteUI);
    }
    public void GoToEditItemUI()
    {
        Debug.Log("GoToEditItemUI");
        UpdateStateDelayed(State.EditItemUI);
    }
    public void GoToRenameItemUI()
    {
        Debug.Log("GoToRenameItemUI");
        UpdateStateDelayed(State.RenameItemUI);
    }

    public void ToggleMenu()
    {
        selectedItem = null;

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
        Debug.Log("Committing text: " + text);
        if (state == State.RenameItemUI || state == State.AddItemUI)
        {
            if (selectedItem != null)
            {
                Debug.Log("Setting selectedItem name to: " + text);
                selectedItem.SetName(text);
            }
            else
            {
                Debug.Log("No item selected for renaming!");
            }
        }
        else
        {
            if (state == State.FindUI)
            {
                PointArrowAtFirstMatch(text);
            }
            else
            {
                Debug.Log("Not in state for renaming! state = " + state);
            }
        }
    }

    void PointArrowAtFirstMatch(string query)
    {
        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        for (int i = 0; i < items.Length; i++)
        {
            if (items[i].name.ToLower().Contains(query.ToLower()))
            {
                arrow.objectToPointAt = items[i].transform;
            }
        }

        UpdateStateDelayed(State.CompassUI);
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
        Debug.Log("OnReleaseItem lastState = " + lastState);
        //state = lastState;
        UpdateStateDelayed(lastState);
    }

    public void OnSearchTileSelected(int tileID)
    {
        string name = buttonFilter.GetNthButtonName(tileID);
        Debug.Log("Selected the search tile ID: " + tileID + " with name " + name);
        PointArrowAtFirstMatch(name);
    }

    public void DeleteSelectedItem()
    {
        if (this.selectedItem != null)
        {
            Destroy(selectedItem.gameObject);
        }
    }
}
