using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveInRange : MonoBehaviour
{

    public enum Direction
    {
        xAxis,
        yAxis
    };

    public Direction direction = Direction.yAxis;
    public float moveSpeed = 1;
    public float maxDistance = 50;

    private Vector2 startPosition;
    private Vector2 updatedPosition;

    // Use this for initialization
    void Start()
    {
        startPosition = transform.position;
        updatedPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (direction == Direction.xAxis)
            updatedPosition.x = startPosition.x + maxDistance * Mathf.Sin(Time.time * moveSpeed);
        else
            updatedPosition.y = startPosition.y + maxDistance * Mathf.Sin(Time.time * moveSpeed);

        transform.position = updatedPosition;
    }
}
