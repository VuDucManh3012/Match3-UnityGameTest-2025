using System.IO;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
[CreateAssetMenu(fileName = "ItemReskinData", menuName = "Item/Reskin Data")]
public class ItemReskinData : ScriptableObject
{
    [FolderPath]
    public string pathPrefab;
    [System.Serializable]
    public class ItemSpritePair
    {
        public ItemCtrl itemCtrl;
        public Sprite newSprite;
    }

    public ItemSpritePair[] itemSprites;

    [Button]
    void GetPrefabItem()
    {
        string[] guids = AssetDatabase.FindAssets("itemNormal", new[] { pathPrefab });
        List<ItemSpritePair> result = new List<ItemSpritePair>();

        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);

            // prefab start "itemNormal"
            string fileName = Path.GetFileNameWithoutExtension(path);
            if (!fileName.StartsWith("itemNormal"))
                continue;

            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefab == null)
            {
                Debug.LogWarning($"Prefab not found at path: {path}");
                continue;
            }

            ItemCtrl ctrl = prefab.GetComponent<ItemCtrl>();
            if (ctrl == null)
            {
                Debug.LogWarning($"ItemCtrl not found on prefab: {path}");
                continue;
            }

            result.Add(new ItemSpritePair
            {
                itemCtrl = ctrl,
                newSprite = null
            });
        }

        itemSprites = result.ToArray();
        Debug.Log($"Found {itemSprites.Length} itemNormal prefabs.");
    }

    [Button]
    void ChangeItemSprite()
    {
        foreach (var pair in itemSprites)
        {
            if (pair.itemCtrl == null || pair.newSprite == null)
            {
                Debug.LogWarning("ItemCtrl or newSprite is null for one of the pairs.");
                continue;
            }
            pair.itemCtrl.SetItemIcon(pair.newSprite);
        }
    }
}
