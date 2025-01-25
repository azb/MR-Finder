using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    MRFinderUI mrFinderUI;

    public GameObject normalRing;
    public GameObject selectedRing;

    public Text label;

    // Start is called before the first frame update
    void Start()
    {
        mrFinderUI = FindObjectOfType<MRFinderUI>();
    }

    // Update is called once per frame
    void Update()
    {
        normalRing.SetActive(mrFinderUI.selectedItem != this);
        selectedRing.SetActive(mrFinderUI.selectedItem == this);
    }

    public void OnGrab()
    {
        mrFinderUI.OnGrabItem();
        mrFinderUI.selectedItem = this;
    }

    public void OnRelease()
    {
        mrFinderUI.OnReleaseItem();
        mrFinderUI.state = MRFinderUI.State.Viewing;
    }

    public void OnLabelPressed()
    {
        Debug.Log("OnLabelPressed");
        mrFinderUI.selectedItem = this;
        mrFinderUI.UpdateStateDelayed(MRFinderUI.State.EditItemUI);
    }

    public void SetName(string name)
    {
        gameObject.name = name;
        label.text = name;
    }
}
