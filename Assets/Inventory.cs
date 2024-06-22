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

    /// <summary>
    /// The inventory will always have this container by default
    /// </summary>
    public ContainerDefinition defaultContainer;
    public ItemDefinitionDictionary itemDictionary;

    private InventoryData inventoryData;
    private ContainerInstance defaultContainerInst;

    //Variable used only to test adding items to the default container for save/load purposes
    public StackableDefinition dummyItem;

    private string filePath;

    public void Awake()
    {
        if (instance == null)
            instance = this;

        filePath = Application.persistentDataPath + DATA_FILE;

        //If failed to load, build the default inventory
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
