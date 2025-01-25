using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRKeyboard : MonoBehaviour
{
    public Text inputText;

    public string keyboardString;
    string cursor;

    public static VRKeyboard Instance;

    public bool capslock = false;

    KeyboardKey[] allKeys;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        Invoke("ToggleCursor", .5f);
    }

    private void OnEnable()
    {
        if (allKeys == null)
        {
            allKeys = FindObjectsOfType<KeyboardKey>();
            Debug.Log("AllKeys.Length = " + allKeys.Length);
        }
    }

    void ToggleCursor()
    {
        if (cursor == "|")
        {
            cursor = " ";
        }
        else
        {
            cursor = "|";
        }
        Invoke("ToggleCursor", .5f);
    }


    // Update is called once per frame
    void Update()
    {
        inputText.text = keyboardString + cursor;
    }
}
