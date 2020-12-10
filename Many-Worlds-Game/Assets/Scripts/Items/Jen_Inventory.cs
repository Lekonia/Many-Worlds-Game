using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jen_Inventory : MonoBehaviour
{
    #region Singleton
    
    public static Jen_Inventory instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instnace of Inventory found!");
            return;
        }

        instance = this;    
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallBack;

    public int space = 20;

    public List<Jen_Item> items = new List<Jen_Item>();

    public bool Add (Jen_Item item)
    {
        if (!item.isDefaultItem)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room.");
                return false;
            }

            items.Add(item);

            if (onItemChangedCallBack != null)
                onItemChangedCallBack.Invoke();
        }

        return true;

    }

    public void Remove (Jen_Item item)
    {
        items.Remove(item);

        if (onItemChangedCallBack != null)
            onItemChangedCallBack.Invoke();
    }
}
