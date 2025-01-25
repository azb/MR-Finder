using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetInputFieldTextToKeyboardString : MonoBehaviour
{
    InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField = GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        inputField.text = VRKeyboard.Instance.keyboardString;
    }
}
