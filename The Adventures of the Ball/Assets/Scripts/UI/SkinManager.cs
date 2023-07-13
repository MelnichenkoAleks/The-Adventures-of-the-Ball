using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class SkinManager : MonoBehaviour
{
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject playerskin;

    public void NextOption()
    {
        selectedSkin = (selectedSkin + 1) % skins.Count;
        sr.sprite = skins[selectedSkin];
    }

    public void BackOption()
    {
        selectedSkin = (selectedSkin - 1 + skins.Count) % skins.Count;
        sr.sprite = skins[selectedSkin];
    }

    public void PlayGame()
    {
#if UNITY_EDITOR
        string prefabPath = "Assets/Prefabs/Player1.prefab";
        GameObject existingPrefab = AssetDatabase.LoadAssetAtPath<GameObject>(prefabPath);

        if (existingPrefab != null)
        {
            
            existingPrefab.GetComponent<SpriteRenderer>().sprite = sr.sprite;
            EditorUtility.SetDirty(existingPrefab);
            AssetDatabase.SaveAssets();
        }
        else
        {
            
            GameObject newPrefab = PrefabUtility.SaveAsPrefabAsset(playerskin, prefabPath);
            if (newPrefab != null)
            {
                Debug.Log("Prefab created: " + prefabPath);
            }
            else
            {
                Debug.LogError("Failed to create prefab at path: " + prefabPath);
            }
        }
#else
        Debug.Log("PlayGame function is called. Do something else here.");
#endif
    }
}
