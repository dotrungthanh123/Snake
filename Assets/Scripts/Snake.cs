using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector3 _direction;
    public GameObject part;
    Vector3 AddPosition;
    List<GameObject> parts = new List<GameObject>();
    [SerializeField] int InitialSize = 4;
    private void Start()
    {
        ResetState();
    }

    private void FixedUpdate()
    {
        AddPosition = parts[parts.Count - 1].transform.position;
        if (_direction != Vector3.zero) {
            for (int i = parts.Count - 1; i > 0; i--)
            {
                parts[i].transform.position = parts[i - 1].transform.position;
            }
        }
        transform.position += _direction;
    }

    private void Update()
    {
        Vector3 _dir = _direction;
        if (Input.GetKeyDown(KeyCode.DownArrow))
            _dir = Vector3.down;
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            _dir = Vector3.up;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            _dir = Vector3.right;
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
            _dir = Vector3.left;
        if (_dir + _direction != Vector3.zero && _dir + _direction != Vector3.left)
            _direction = _dir;
    }

    private void ResetState()
    {
        for (int i = parts.Count - 1; i > 0; i--)
        {
            Destroy(parts[i]);
        }
        parts.Clear();
        parts.Add(gameObject);
        _direction = Vector3.zero;
        transform.position = Vector3.zero;
        var food = FindObjectOfType<Food>();
        food.gameObject.SetActive(false);
        food.gameObject.SetActive(true);

        for (int i = 0; i < InitialSize - 1; i++)
        {
            var InitialPart = Instantiate(part, parts[i].transform.position + Vector3.left, Quaternion.identity);
            parts.Add(InitialPart);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            var newPart = Instantiate(part);
            newPart.transform.position = AddPosition;
            parts.Add(newPart);
        }
        else
        {
            ResetState();
        }
    }
}
