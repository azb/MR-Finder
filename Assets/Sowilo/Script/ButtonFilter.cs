using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonFilter : MonoBehaviour
{
    public InputField inputField; // 输入框 (InputField for text input)
    public Transform content; // Content 对象 (Parent object containing all child items)

    private List<Transform> childList = new List<Transform>(); // 子物体列表 (List of child objects)

    private void Start()
    {
        // 初始化子物体列表 (Initialize the child object list)
        //PopulateChildList();

        // 监听 InputField 的文字变化事件 (Listen to text changes in the InputField)
        inputField.onValueChanged.AddListener(OnInputValueChanged);

        Invoke("PopulateChildList",.01f);
    }

    // 遍历 Content 的子物体，添加到列表中 (Populate the list with Content's children)
    private void PopulateChildList()
    {
        Item[] items = FindObjectsOfType<Item>();

        childList.Clear(); // 清空列表 (Clear the list)

        Debug.Log("items.Length = " + items.Length);

        int currentItem = 0;
        foreach (Transform child in content)
        {
            childList.Add(child); // 将每个子物体添加到列表中 (Add each child to the list)

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
            // 获取子物体下的 TMP_Text 组件 (Get the TMP_Text component under the child object)
            TMP_Text nameText = child.GetComponentInChildren<TMP_Text>();

            if (nameText != null)
            {
                Debug.Log("nameText = " + nameText);
                Debug.Log("VRKeyboard.Instance = " + VRKeyboard.Instance);
                Debug.Log("currentItem = " + currentItem);
                Debug.Log("items = " + items);
                // 如果名字包含输入的文字，则显示子物体，否则隐藏
                // (Show the child object if its name contains the input text, otherwise hide it)
                if (nameText.text.ToLower().Contains(VRKeyboard.Instance.keyboardString.ToLower())
                    && currentItem < items.Length) // 忽略大小写 (Case-insensitive)
                {
                    child.gameObject.SetActive(true); // 显示子物体 (Show the child object)
                }
                else
                {
                    child.gameObject.SetActive(false); // 隐藏子物体 (Hide the child object)
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

    // 当输入框内容变化时调用 (Called when the text in the InputField changes)
    private void OnInputValueChanged(string input)
    {
        //PopulateChildList();

        Debug.Log("input = " + input);
        // 遍历子物体列表，筛选显示或隐藏 (Iterate through the child list to show or hide objects)
    }

    private void OnDestroy()
    {
        // 移除监听器，避免内存泄漏 (Remove the listener to avoid memory leaks)
        inputField.onValueChanged.RemoveListener(OnInputValueChanged);
    }
}
