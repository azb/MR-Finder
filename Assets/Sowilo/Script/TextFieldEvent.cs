using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TextFieldEvent : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public UnityEvent onSelectEvent;
    public UnityEvent disSelectEvent;


    private InputField inputField;
    private GameObject virtualKeyboard;
    // Start is called before the first frame update
    void Start()
    {
        // get this InputField 
        inputField = GetComponent<InputField>();
virtualKeyboard = GameObject.Find("[BuildingBlock] Virtual Keyboard");

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //LINK with [BuildingBlock] Virtual Keyboard.KeyboardInputManager to controller OPEN/CLOSE&Change inputfield

    //  InputField select trigger
    public void OnSelect(BaseEventData eventData)
    {
        onSelectEvent.Invoke();
        virtualKeyboard.GetComponent<KeyboardInputManager>().InputFieldSelect(inputField);
    }

    //  InputField disselect trigger
    public void OnDeselect(BaseEventData eventData)
    {
        disSelectEvent.Invoke();
        virtualKeyboard.GetComponent<KeyboardInputManager>().InputFieldDisSelect();

    }
}
