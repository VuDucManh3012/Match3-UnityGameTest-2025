using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemReskinData", menuName = "Item/Reskin Data")]
public class ItemReskinData : ScriptableObject
{
    public string pathPrefab;
    [System.Serializable]
    public class ItemSpritePair
    {
        public string itemName;
        public Sprite newSprite;
    }

    public ItemSpritePair[] itemSprites;
}
