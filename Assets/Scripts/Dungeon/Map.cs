using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public List<Rect> spawnRects = new();
    int lastUseRectIndex = -1;

    public Vector2 GetRandomPos()
    {
        int randIndex = Random.Range(0, spawnRects.Count);
        lastUseRectIndex = randIndex;
        float randX = Random.Range(spawnRects[randIndex].xMin, spawnRects[randIndex].xMax);
        float randY = Random.Range(spawnRects[randIndex].yMin, spawnRects[randIndex].yMax);
        return new Vector2(randX, randY);
    }

    public Vector3 GetLastUseRectRandomPos()
    {
        if (lastUseRectIndex == -1) return GetRandomPos();

        float randX = Random.Range(spawnRects[lastUseRectIndex].xMin, spawnRects[lastUseRectIndex].xMax);
        float randY = Random.Range(spawnRects[lastUseRectIndex].yMin, spawnRects[lastUseRectIndex].yMax);
        return new Vector2(randX, randY);
    }

    private void OnDrawGizmosSelected()
    {
        foreach (Rect rect in spawnRects)
        {
            float centerX, centerY;
            centerX = (rect.xMin + rect.xMax) / 2;
            centerY = (rect.yMin + rect.yMax) / 2;

            Gizmos.DrawCube(new Vector3(centerX, centerY), new Vector3(rect.width, rect.height));
        }
    }
}
