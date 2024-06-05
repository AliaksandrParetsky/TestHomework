using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private List<Transform> prefabs = new List<Transform>();

    private Transform GetRandomPrefab()
    {
        var randomIndex = Random.Range(0, prefabs.Count);

        return prefabs[randomIndex];
    }

    private void CreatePrefab()
    {
        var rotation = Quaternion.identity;
        var position = new Vector3(0f,2f,0f);

        Instantiate(GetRandomPrefab(), position, rotation);
    }

    public void OnCreateObject()
    {
        for (int index = 0; index < prefabs.Count; index++)
        {
            if (prefabs[index] == null)
            {
                Debug.LogError($"Prefab under index number {index} is NULL!");
                return;
            }
        }

        CreatePrefab();
    }
}
