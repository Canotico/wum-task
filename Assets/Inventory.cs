using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class Inventory : MonoBehaviour
{
    private const string DATA_FILE = "/InventoryData.json";

    private static Inventory instance;

    public static Inventory Instance{ get{ return instance; }}

    public ContainerDefinition defaultContainer;
    public ItemDefinitionDictionary itemDictionary;

    private InventoryData inventoryData;
    private ContainerInstance defaultContainerInst;

    public StackableDefinition dummyItem;

    private string filePath;

    public void Awake()
    {
        if (instance == null)
            instance = this;

        filePath = Application.persistentDataPath + DATA_FILE;

        if (!Load())
        {
            CreateDefaultInventory();
        }

        for (int i = 0; i < 3; i++)
        {
            defaultContainerInst.AddItem(new StackableInstance(dummyItem));
        }
    }

    private void CreateDefaultInventory()
    {
        defaultContainerInst = new ContainerInstance(defaultContainer);
        inventoryData = new InventoryData();
        inventoryData.defaultContainer = defaultContainerInst;
        Debug.Log("Created default Inventory");
    }

    public void Save()
    {
        /*File.WriteAllText(filePath, JsonUtility.ToJson(inventoryData));
        Debug.Log("Saved Inventory data at: " + filePath);*/

        using (FileStream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
        {
            using (StreamWriter writer = new StreamWriter(stream))
            {
                string jsonString = JsonConvert.SerializeObject(inventoryData);
                writer.Write(jsonString);
            }
        }

        Debug.Log("Saved Inventory data at: " + filePath);
    }
    
    public bool Load()
    {
        /*if (!File.Exists(filePath))
        {
            Debug.Log("Failed to load Inventory Data. File not found.");
            return false;
        }

        inventoryData = JsonUtility.FromJson<InventoryData>(File.ReadAllText(filePath));
        defaultContainerInst = inventoryData.defaultContainer;
        Debug.Log("Loaded Inventory data successfully");

        return true;*/

        using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                string jsonString = reader.ReadToEnd();
                inventoryData = JsonConvert.DeserializeObject<InventoryData>(jsonString);
                defaultContainerInst = inventoryData.defaultContainer;
            }
        }

        Debug.Log("Loaded Inventory data successfully");
        return true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
            Load();
        else if (Input.GetKeyDown(KeyCode.S))
            Save();
    }
}
