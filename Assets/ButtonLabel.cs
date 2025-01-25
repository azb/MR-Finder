using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ButtonLabel : MonoBehaviour
{
    Text text;

    #if UNITY_EDITOR
    // Start is called before the first frame update
    void Update()
    {
        text = GetComponentInChildren<Text>();
        text.text = gameObject.name.Replace(" Button", "");
    }
    #endif   
}
