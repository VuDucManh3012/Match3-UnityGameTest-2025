using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

#if UNITY_EDITOR
using UnityEditor;
#endif
public class ItemCtrl : MonoBehaviour
{
    [Title("")]
    [SerializeField]private SpriteRenderer _itemIcon;

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    public void SetItemIcon(Sprite newItemIcon)
    {
        if (newItemIcon == null)
        {
            _itemIcon.sprite = null;
            return;
        }

        Sprite oldSprite = _itemIcon.sprite;
        _itemIcon.sprite = newItemIcon;

        if (oldSprite != null)
        {
            Vector2 oldSize = oldSprite.bounds.size;
            Vector2 newSize = newItemIcon.bounds.size;

            if (newSize.x > 0 && newSize.y > 0)
            {
                Vector3 originalScale = _itemIcon.transform.localScale;
                Vector3 newScale = new Vector3(
                    originalScale.x * oldSize.x / newSize.x,
                    originalScale.y * oldSize.y / newSize.y,
                    originalScale.z
                );
                _itemIcon.transform.localScale = newScale;
            }
        }
#if UNITY_EDITOR
        EditorUtility.SetDirty(this.gameObject);
#endif
    }
}
