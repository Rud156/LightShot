using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public float followSpeed = 5f;

    private Transform player;
    private Vector2 lastPlayerPosition;

    // Use this for initialization
    void Start() => player = GameObject.FindGameObjectWithTag(TagManager.Player).transform;

    // Update is called once per frame
    void Update() => UpdateLastPlayerPosition();

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate() => MoveCameraIntoView();

    private void MoveCameraIntoView() =>
        transform.position =
            Vector3.Lerp(transform.position,
            new Vector3(lastPlayerPosition.x, lastPlayerPosition.y, -10),
            followSpeed * Time.deltaTime);


    private void UpdateLastPlayerPosition()
    {
        if (player != null)
            lastPlayerPosition = player.position;
    }
}
