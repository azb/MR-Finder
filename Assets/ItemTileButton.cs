using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro; // Add TMPro namespace

public class ItemTileButton : MonoBehaviour
{
    Toggle toggle;

    MRFinderUI mrFinderUI;
    ButtonRecord buttonRecord;
    TextMeshProUGUI itemText; // Add variable for TextMeshPro component

    // Start is called before the first frame update
    void Start()
    {
        buttonRecord = FindObjectOfType<ButtonRecord>();
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate { TileButtonPressed(); });
        itemText = GetComponentInChildren<TextMeshProUGUI>(); // Get TextMeshPro component from children
    }

    public void TileButtonPressed()
    {
        int childIndex = transform.GetSiblingIndex();
        Debug.Log("TileButtonPressed "+ childIndex);
        MRFinderUI.Instance.OnSearchTileSelected(childIndex);
        buttonRecord.RecordSearchEvent(itemText.gameObject);
    }
}

