using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemTileButton : MonoBehaviour
{
    Toggle toggle;

    MRFinderUI mrFinderUI;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.onValueChanged.AddListener(delegate { TileButtonPressed(); });
    }

    public void TileButtonPressed()
    {
        int childIndex = transform.GetSiblingIndex();
        MRFinderUI.Instance.OnSearchTileSelected(childIndex);
    }
}
