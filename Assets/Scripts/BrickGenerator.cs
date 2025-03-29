using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickGenerator : MonoBehaviour
{
    [SerializeField] GameObject brickPrefab;

    [SerializeField] int numRows;
    [SerializeField] int numCols;

    [SerializeField] private Gradient brickGradient;
    // Start is called before the first frame update
    void Start()
    {
        Camera mainCamera = Camera.main;
        
        Vector3 topLeft = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height));
        Vector3 topRight = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        float brickLength = (topRight.x - topLeft.x) / numCols;

        Vector3 currentBrickLocation = new Vector3(topLeft.x + brickLength / 2, topLeft.y - brickPrefab.transform.localScale.y / 2, 0);
        
        float currentGradient = 0;
        float stepSize = 1f / numRows;
        
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                GameObject brick = Instantiate(brickPrefab, currentBrickLocation, Quaternion.identity);
                brick.GetComponent<SpriteRenderer>().color = brickGradient.Evaluate(currentGradient);
                Vector3 scale = brick.transform.localScale;
                brick.transform.localScale = new Vector3(brickLength, scale.y);
                currentBrickLocation.x += brickLength;
            }
            currentBrickLocation.x = topLeft.x + brickLength / 2;
            currentBrickLocation.y -= brickPrefab.transform.localScale.y;
            currentGradient += stepSize;
        }
    }
}
