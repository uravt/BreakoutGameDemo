using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    public Vector3 velocity;
    
    private Camera mainCamera;

    [SerializeField] float speed;
    
    Vector3 bottomLeft;
    Vector3 topRight; 
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        velocity = new Vector3(1, 1).normalized;
        bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0));
        topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;

        position.x += Time.deltaTime * velocity.x * speed;
        position.x = Mathf.Clamp(position.x, bottomLeft.x, topRight.x);
        if (Mathf.Approximately(position.x, bottomLeft.x) || Mathf.Approximately(position.x, topRight.x))
        {
            velocity.x = -velocity.x;
        }

        position.y += Time.deltaTime * velocity.y * speed;
        position.y = Mathf.Clamp(position.y, bottomLeft.y, topRight.y);
        if (Mathf.Approximately(position.y, bottomLeft.y) || Mathf.Approximately(position.y, topRight.y))
        {
            velocity.y = -velocity.y;
        }

        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Brick"))
        {
            Destroy(other.gameObject);
        }
        velocity.y = -velocity.y;
    }
}
