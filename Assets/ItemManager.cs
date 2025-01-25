using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class ItemData
{
    public string name;
    public Vector3 position;
}

[System.Serializable]
public class ItemDataList
{
    public List<ItemData> items = new List<ItemData>();
}

public class ItemManager : MonoBehaviour
{
    public string jsonFileName = "ItemData.json";
    public GameObject itemPrefab; // Assign the Item prefab in the Inspector

    private void Start()
    {
        if (File.Exists(GetFilePath()))
        {
            LoadItems();
        }
        else
        {
            SaveItems();
        }
    }

    private string GetFilePath()
    {
        return Path.Combine(Application.persistentDataPath, jsonFileName);
    }

    public void SaveItems()
    {
        ItemDataList itemDataList = new ItemDataList();

        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        foreach (GameObject item in items)
        {
            ItemData data = new ItemData
            {
                name = item.name,
                position = item.transform.position
            };
            itemDataList.items.Add(data);
        }

        string json = JsonUtility.ToJson(itemDataList, true);
        File.WriteAllText(GetFilePath(), json);

        Debug.Log($"Saved {itemDataList.items.Count} items to {GetFilePath()}");
    }

    public void LoadItems()
    {
        string filePath = GetFilePath();
        if (!File.Exists(filePath))
        {
            Debug.LogError("File not found: " + filePath);
            return;
        }

        string json = File.ReadAllText(filePath);
        ItemDataList itemDataList = JsonUtility.FromJson<ItemDataList>(json);

        foreach (ItemData data in itemDataList.items)
        {
            GameObject newItem = Instantiate(itemPrefab);
            newItem.name = data.name;
            newItem.transform.position = data.position;
        }

        Debug.Log($"Loaded {itemDataList.items.Count} items from {filePath}");
    }
}
