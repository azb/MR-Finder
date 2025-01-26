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
            MRFinderUI.Instance.KeyboardCommitText(VRKeyboard.Instance.keyboardString);

            //if (MRFinderUI.Instance.selectedItem != null)
            //{
            //    MRFinderUI.Instance.selectedItem.gameObject.name = VRKeyboard.Instance.keyboardString;
            //    MRFinderUI.Instance.selectedItem = null;
            //}

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
            Debug.Log("Capslock pressed VRKeyboard.Instance.allKeys.Length = "+ VRKeyboard.Instance.allKeys.Length);
            VRKeyboard.Instance.capslock = !VRKeyboard.Instance.capslock;
            for (int i = 0; i < VRKeyboard.Instance.allKeys.Length; i++)
            {
                VRKeyboard.Instance.allKeys[i].UpdateCapslock();
            }
        }
        else
        {
            VRKeyboard.Instance.keyboardString += gameObject.name;
        }
    }

    public void UpdateCapslock()
    {
        Debug.Log("UpdateCapslock "+ gameObject.name);
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        string name = gameObject.name.ToLower();

        if (name.Length == 1 && alphabet.Contains(name))
        {
            //is a letter
            if (VRKeyboard.Instance.capslock)
            {
                gameObject.name = gameObject.name.ToUpper();
            }
            else
            {
                gameObject.name = gameObject.name.ToLower();
            }
        }
    }
}
