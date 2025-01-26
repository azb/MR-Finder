using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonFilter : MonoBehaviour
{
    public InputField inputField; // ����� (InputField for text input)
    public Transform content; // Content ���� (Parent object containing all child items)

    private List<Transform> childList = new List<Transform>(); // �������б� (List of child objects)

    private void Start()
    {
        // ��ʼ���������б� (Initialize the child object list)
        //PopulateChildList();

        // ���� InputField �����ֱ仯�¼� (Listen to text changes in the InputField)
        inputField.onValueChanged.AddListener(OnInputValueChanged);

        Invoke("PopulateChildList",.01f);
    }

    // ���� Content �������壬��ӵ��б��� (Populate the list with Content's children)
    private void PopulateChildList()
    {
        Item[] items = FindObjectsOfType<Item>();

        childList.Clear(); // ����б� (Clear the list)

        Debug.Log("items.Length = " + items.Length);

        int currentItem = 0;
        foreach (Transform child in content)
        {
            childList.Add(child); // ��ÿ����������ӵ��б��� (Add each child to the list)

            child.gameObject.SetActive(currentItem < items.Length);

            TMP_Text nameText = child.GetComponentInChildren<TMP_Text>();

            //Set the name of each search tile to the name of an item in the scene
            if (currentItem < items.Length)
            {
                Debug.Log("Adding item "+items[currentItem].gameObject.name);
                nameText.text = items[currentItem].gameObject.name;
            }
            else
            {
                child.gameObject.SetActive(false);
            }
            currentItem++;
        }

        currentItem = 0;
        foreach (Transform child in childList)
        {
            // ��ȡ�������µ� TMP_Text ��� (Get the TMP_Text component under the child object)
            TMP_Text nameText = child.GetComponentInChildren<TMP_Text>();

            if (nameText != null)
            {
                Debug.Log("nameText = " + nameText);
                Debug.Log("VRKeyboard.Instance = " + VRKeyboard.Instance);
                Debug.Log("currentItem = " + currentItem);
                Debug.Log("items = " + items);
                // ������ְ�����������֣�����ʾ�����壬��������
                // (Show the child object if its name contains the input text, otherwise hide it)
                if (nameText.text.ToLower().Contains(VRKeyboard.Instance.keyboardString.ToLower())
                    && currentItem < items.Length) // ���Դ�Сд (Case-insensitive)
                {
                    child.gameObject.SetActive(true); // ��ʾ������ (Show the child object)
                }
                else
                {
                    child.gameObject.SetActive(false); // ���������� (Hide the child object)
                }
            }
            currentItem++;
        }
        Invoke("PopulateChildList", 1f);
    }

    public string GetNthButtonName(int n)
    {
        TMP_Text nameText = childList[n].GetComponentInChildren<TMP_Text>();
        string name = nameText.text;
        return name;
    }

    // ����������ݱ仯ʱ���� (Called when the text in the InputField changes)
    private void OnInputValueChanged(string input)
    {
        //PopulateChildList();

        Debug.Log("input = " + input);
        // �����������б�ɸѡ��ʾ������ (Iterate through the child list to show or hide objects)
    }

    private void OnDestroy()
    {
        // �Ƴ��������������ڴ�й© (Remove the listener to avoid memory leaks)
        inputField.onValueChanged.RemoveListener(OnInputValueChanged);
    }
}
