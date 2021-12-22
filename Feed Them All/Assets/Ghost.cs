using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("Player"))
        {
            Debug.Log("I hit the player");
            this.gameObject.SetActive(false);

            Vector3 spawnObjectPos = transform.position;
            ObjectPooler.Instance.SpawnFromPool("Player", spawnObjectPos, Quaternion.identity);
        }
    }
}
