using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // private void OnCollisionEnter(Collision other)
    // {
    //     if (other.collider.gameObject.CompareTag("Ghost"))
    //     {
    //         Debug.Log("I hit the ghost");
    //         other.gameObject.SetActive(false);

    //         Vector3 spawnObjectPos = transform.position;
    //         Vector3 newPos = transform.position + new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f));
    //         transform.position = newPos;
    //         ObjectPooler.Instance.SpawnFromPool("Player", spawnObjectPos, Quaternion.identity);
    //     }

    //     if (other.collider.gameObject.CompareTag("Obstacle"))
    //     {
    //         Debug.Log("I hit the obstacle, lemme die");
    //         this.gameObject.SetActive(false);
    //     }
    // }
}
