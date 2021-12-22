using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

public class Gate : MonoBehaviour
{
    [SerializeField] private int value;

    [Dropdown("Operation")]
    public string operation;

    private bool isPlayerDetected = false;
    private int spawnCount = 0;


    private DropdownList<string> Operation()
    {
        return new DropdownList<string>()
        {
            { "+",   "+" },
            { "*",    "*" }
        };
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !isPlayerDetected)
        {
            isPlayerDetected = true;

            switch (operation)
            {
                case "+":
                    spawnCount += value;
                    break;
                case "*":
                    spawnCount = 1 * value;
                    break;
                default:
                    Debug.Log("no valid operation");
                    break;
            }
            ObjectPooler.Instance.SpawnWithValue("Player",spawnCount,transform.position,Quaternion.identity);
            // Debug.Log(value + operation);
        }
    }


}
