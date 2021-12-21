using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class RoadController : MonoBehaviour
{
    public Vector3 currentDirection = new Vector3(0, 0, 0);
    public List<GameObject> roads;

    [BoxGroup("Road Settings")]
    public GameObject roadPrefab;
    public Transform roadParent;

    [BoxGroup("Road Settings")]
    [Dropdown("RoadDirection")]
    public Vector3 pointDirection;

    [BoxGroup("Road Settings")]
    public float roadDistance = 5f;


    [Button("Add road")]
    public void AddRoad()
    {
        // Gelen directiona göre aralıklı aralıklı her basıldığında spawn edecek

        if (!(roads.Count == 0))
        {
            currentDirection += pointDirection * roadDistance;
        }

        GameObject road = Instantiate(roadPrefab, currentDirection, Quaternion.identity);
        road.transform.SetParent(roadParent);
        roads.Add(road);

    }

    [Button("Remove road")]
    public void RemoveRoad()
    {
        if (!(roads.Count == 0))
        {
            DestroyImmediate(roads[roads.Count - 1]);
            currentDirection -= pointDirection * roadDistance;
            roads.RemoveAt(roads.Count - 1);

        }
        else
        {
            Debug.Log("Roads is empty!!");
        }
    }

    [Button("Clear Roads")]
    public void ClearAllRoads()
    {
        foreach (GameObject road in roads)
        {
            DestroyImmediate(road);
        }

        roads.Clear();
        currentDirection = new Vector3(0, 0, 100);
    }

    private DropdownList<Vector3> RoadDirection()
    {
        return new DropdownList<Vector3>()
        {
            { "X : Right",   Vector3.right },
            { "X : Left",    Vector3.left },
            { "Z : Forward", Vector3.forward },
            { "Z : Back",    Vector3.back }
        };
    }
}
