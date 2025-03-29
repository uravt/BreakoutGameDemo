using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float speed;
    private Camera mainCamera;

    private Vector3 bottomLeft;
    private Vector3 topRight;
    private float offset;

    private void Start()
    {
        mainCamera = Camera.main;
        bottomLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, 0));
        topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));
        offset = gameObject.transform.localScale.x / 2;
    }

    void Update()
    {
        Vector3 position = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            position.x += -speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            position.x += speed * Time.deltaTime;
        }
        position.x = Mathf.Clamp(position.x, bottomLeft.x + offset, topRight.x - offset);
        transform.position = position;
    }
}
