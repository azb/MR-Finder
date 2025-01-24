using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class KeyboardInputManager : MonoBehaviour
{
    public InputField inputFieldToKeyboard; 
    public string text;

    private OVRVirtualKeyboardInputFieldTextHandler textHandler;


    private void Awake()
    {
        textHandler = gameObject.GetComponent<OVRVirtualKeyboardInputFieldTextHandler>();   }


    /// <summary>
    /// Triggered when input is change
    /// </summary>
    /// <param name="input"></param>
    private void OnInputValueChanged(string input)
    {
        text = input.Trim();
        Debug.Log($"[real time input]: {text}");
    }

    /// <summary>
    /// Triggered when input is complete
    /// </summary>
    private void OnInputEndEdit(string input)
    {
        text = input.Trim();
        Debug.Log($"[real time input]: {text}");
    }

    /// <summary>
    /// inputField Select Reference
    /// </summary>
    /// <param name="inputField"></param>
    public void InputFieldSelect(InputField inputField)
    {
        inputFieldToKeyboard = inputField;
        textHandler.InputField = inputField;
        gameObject.SetActive(true);
        gameObject.GetComponent<OVRVirtualKeyboard>().enabled = true;


        if (inputFieldToKeyboard != null)
        {
            inputFieldToKeyboard.onValueChanged.AddListener(OnInputValueChanged);
            inputFieldToKeyboard.onEndEdit.AddListener(OnInputEndEdit);
        }
    }

    /// <summary>
    /// inputField Unselect Reference
    /// </summary>
    public void InputFieldDisSelect()
    {

        if (inputFieldToKeyboard != null)
        {
            inputFieldToKeyboard.onValueChanged.RemoveListener(OnInputValueChanged);
            inputFieldToKeyboard.onEndEdit.RemoveListener(OnInputEndEdit);
        }

        inputFieldToKeyboard = null;
        textHandler.InputField = null;
        gameObject.GetComponent<OVRVirtualKeyboard>().enabled = false;

    }
}
