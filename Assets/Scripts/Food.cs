using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public BoxCollider2D boundary;

    private void OnEnable() {
        RandomPosition();
    }

    private void RandomPosition() {
        float x = Random.Range(-boundary.bounds.size.x / 2, boundary.bounds.size.x / 2);
        float y = Random.Range(-boundary.bounds.size.y / 2, boundary.bounds.size.y / 2);
        transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        RandomPosition();
    }
}
