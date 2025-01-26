using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    MRFinderUI mrFinderUI;

    public GameObject normalRing;
    public GameObject selectedRing;
    public GameObject canvas;

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

        if (MRFinderUI.Instance.state == MRFinderUI.State.CompassUI)
        {
            normalRing.SetActive(false);
            selectedRing.SetActive(MRFinderUI.Instance.selectedItem == this);
            canvas.SetActive(MRFinderUI.Instance.selectedItem == this);
        }
        else
        {
            canvas.SetActive(true);
        }
    }

    public void OnGrab()
    {
        mrFinderUI.OnGrabItem();
        mrFinderUI.selectedItem = this;
    }

    public void OnRelease()
    {
        mrFinderUI.OnReleaseItem();
    }

    public void OnLabelPressed()
    {
        if (mrFinderUI.state == MRFinderUI.State.EditItemUI)
        {
            mrFinderUI.selectedItem = null;
            mrFinderUI.UpdateStateDelayed(MRFinderUI.State.Viewing);
        }
        else
        {
            mrFinderUI.selectedItem = this;
            mrFinderUI.UpdateStateDelayed(MRFinderUI.State.EditItemUI);
        }
    }

    public void SetName(string name)
    {
        Debug.Log("Setting name to " + name);
        gameObject.name = name;
        label.text = name;
    }
}
