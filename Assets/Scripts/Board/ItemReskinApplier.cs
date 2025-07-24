using UnityEngine;
using UnityEditor;

public class ItemReskinApplier : MonoBehaviour
{
    [SerializeField] private ItemReskinData reskinData;

#if UNITY_EDITOR
    [ContextMenu("Apply Reskin")]
    public void ApplyReskin()
    {
        foreach (var pair in reskinData.itemSprites)
        {
            string path = reskinData.pathPrefab + pair.itemName + ".prefab";
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefab == null)
            {
                Debug.LogWarning($"Prefab not found: {pair.itemName}");
                continue;
            }

            SpriteRenderer sr = prefab.GetComponent<SpriteRenderer>();
            if (sr != null && pair.newSprite != null)
            {
                Sprite oldSprite = sr.sprite;
                sr.sprite = pair.newSprite;

                if (oldSprite != null)
                {
                    Vector2 oldSize = oldSprite.bounds.size;
                    Vector2 newSize = pair.newSprite.bounds.size;

                    if (newSize.x > 0 && newSize.y > 0)
                    {
                        Vector3 originalScale = prefab.transform.localScale;
                        Vector3 newScale = new Vector3(
                            originalScale.x * oldSize.x / newSize.x,
                            originalScale.y * oldSize.y / newSize.y,
                            originalScale.z
                        );
                        prefab.transform.localScale = newScale;
                    }
                }

                EditorUtility.SetDirty(prefab);
                Debug.Log($"Applied sprite and scaled {pair.itemName}");
            }
        }

        AssetDatabase.SaveAssets();
    }
#endif
}
