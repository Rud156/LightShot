using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipSpriteBasedOnMouse : MonoBehaviour
{
    public Camera mainCamera;
    public Transform playerTransform;
    public SpriteRenderer playerRenderer;
    public float minOffset = 0.5f;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        float mouseX = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
        float playerX = playerTransform.position.x;

        if (mouseX < playerX - minOffset)
            playerRenderer.flipX = true;
        else if (mouseX > playerX + minOffset)
            playerRenderer.flipX = false;
    }
}
