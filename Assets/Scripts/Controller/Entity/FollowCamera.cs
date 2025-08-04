using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FollowCamera : MonoBehaviour
{
    public Tilemap tilemap;
    [SerializeField] private Transform target;
    private Vector2 minBounds;
    private Vector2 maxBounds;
    private float halfWidth;
    private float halfHeight;

    public void SetTilemap(Tilemap newTilemap)
    {
        tilemap = newTilemap;
        Bounds bounds = tilemap.localBounds;
        minBounds = bounds.min;
        maxBounds = bounds.max;
    }



    private void Start()
    {
        Camera camera = Camera.main;
        halfHeight = camera.orthographicSize;
        halfWidth = halfHeight * camera.aspect;

        
    }

    private void Update()
    {
        Vector3 targetPos = target.position;
        
        float clampedX = Mathf.Clamp(targetPos.x, min: minBounds.x + halfWidth, max: maxBounds.x+halfWidth);
        float clampedY = Mathf.Clamp(targetPos.y, min: minBounds.y + halfHeight, max: maxBounds.y + halfHeight);

        targetPos.x = clampedX;
        targetPos.y = clampedY;
        targetPos.z = -10;


        transform.position = targetPos;
    }

}
