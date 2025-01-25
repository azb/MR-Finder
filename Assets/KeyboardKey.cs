using Oculus.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardKey : MonoBehaviour
{
    InteractableUnityEventWrapper wrapper;
    // Start is called before the first frame update
    void Start()
    {
        wrapper = GetComponentInChildren<InteractableUnityEventWrapper>();
        wrapper._whenUnselect.AddListener(OnPress);
    }

    // Update is called once per frame
    public void OnPress()
    {
        string name = gameObject.name.ToLower();

        if (name.Contains("back"))
        {
            string originalString = VRKeyboard.Instance.keyboardString;
            if (originalString.Length > 0)
            {
                VRKeyboard.Instance.keyboardString =
                    originalString.Remove(originalString.Length - 1);
            }
        }
        else
        if (name.Contains("clear"))
        {
            VRKeyboard.Instance.keyboardString = "";
        }
        else
        if (name.Contains("enter"))
        {
            MRFinderUI.Instance.selectedItem.gameObject.name = VRKeyboard.Instance.keyboardString;
            MRFinderUI.Instance.UpdateStateDelayed(MRFinderUI.State.StartUI);
        }
        else
        if (name.Contains("space"))
        {
            VRKeyboard.Instance.keyboardString += " ";
        }
        else
        if (name.Contains("caps"))
        {
            VRKeyboard.Instance.capslock = !VRKeyboard.Instance.capslock;
        }
        else
        {
            VRKeyboard.Instance.keyboardString += gameObject.name;
        }
    }
}
