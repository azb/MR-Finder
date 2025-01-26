using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ButtonRecord : MonoBehaviour
{

public void RecordSearchEvent(GameObject toggle)
    {
       string itemname = toggle.GetComponent<TMP_Text>().text;
        new Cognitive3D.CustomEvent("Find item: "+itemname)
        .Send();
    }
}
