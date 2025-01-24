using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardInputManager : MonoBehaviour
{
    public InputField inputFieldToKeyboard; 
    public string text;

    private GameObject virtualKeyboard;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    private void OnEnable()
    {
        if (inputFieldToKeyboard != null)
        {
            inputFieldToKeyboard.onValueChanged.AddListener(OnInputValueChanged);
            inputFieldToKeyboard.onEndEdit.AddListener(OnInputEndEdit);
        }
    }

    private void OnDisable()
    {
        if (inputFieldToKeyboard != null)
        {
            inputFieldToKeyboard.onValueChanged.RemoveListener(OnInputValueChanged);
            inputFieldToKeyboard.onEndEdit.RemoveListener(OnInputEndEdit);
        }
    }
    private void OnInputValueChanged(string input)
    {
        text = input.Trim();
        Debug.Log($"[real time input]: {text}");
    }

    /// <summary>
    /// 当输入完成后触发
    /// </summary>
    private void OnInputEndEdit(string input)
    {
        text = input.Trim();
        Debug.Log($"[final input]: {text}");
    }

    public void InputFieldLink(InputField inputField)
    {
        inputFieldToKeyboard = inputField;
        
    }
}
