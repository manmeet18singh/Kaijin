using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Kaijin/Item", order = 0)]
public class Item : ScriptableObject { 
    new public string name = "Heart";
    public Sprite icon = null;
    public bool isDefaultItem = false;
}