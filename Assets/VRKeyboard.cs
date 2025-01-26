using Meta.Voice.Samples.Dictation;
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

    public KeyboardKey[] allKeys;

    bool isListeningVoice = false;

    public GameObject KeyboardCanvas;
    public GameObject VoiceCanvas;

    DictationActivation da;

    // Start is called before the first frame update
    void Awake()
    {
        da = FindObjectOfType< DictationActivation >();
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

    private void OnDisable()
    {
        Invoke("ClearKeyboardString", .5f);
    }

    void ClearKeyboardString()
    {
        keyboardString = "";
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
        if (!this.isListeningVoice)
        {
            inputText.text = keyboardString + cursor;
        }
    }

    public void ToggleListening()
    {
        isListeningVoice = !isListeningVoice;

        KeyboardCanvas.SetActive(!isListeningVoice);
        VoiceCanvas.SetActive(isListeningVoice);

        da = FindObjectOfType<DictationActivation>();
        da.ToggleActivation();
    }
}
