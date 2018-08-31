using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    [Header("Player")]
    public float playerFollowSpeed = 5f;
    public float bufferTime = 3f;

    [Header("Portal")]
    public Transform portal;
    public float moveToPortalSpeed = 1f;
    public float waitTimeForPortal = 5f;

    private Transform player;
    private MovePlayer playerController;
    private Vector2 lastPosition;

    private Transform currentTarget;
    private float currentMovementSpeed;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(TagManager.Player).transform;
        playerController = player.GetComponent<MovePlayer>();

        playerController.displayInput = true;

        StartCoroutine(DisplayPortalThenFollowPLayer());
    }

    // Update is called once per frame
    void Update() => UpdateLastPosition();

    /// <summary>
    /// This function is called every fixed framerate frame, if the MonoBehaviour is enabled.
    /// </summary>
    void FixedUpdate() => MoveCameraIntoView();

    private void MoveCameraIntoView() =>
        transform.position =
            Vector3.Lerp(transform.position,
            new Vector3(lastPosition.x, lastPosition.y, -10),
            currentMovementSpeed * Time.deltaTime);


    private void UpdateLastPosition()
    {
        if (currentTarget != null)
            lastPosition = currentTarget.position;
    }

    IEnumerator DisplayPortalThenFollowPLayer()
    {
        yield return new WaitForSeconds(bufferTime);

        currentTarget = portal;
        currentMovementSpeed = moveToPortalSpeed;

        yield return new WaitForSeconds(waitTimeForPortal);

        currentTarget = player;
        currentMovementSpeed = playerFollowSpeed;
        playerController.displayInput = false;
    }
}
