using System;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    [SerializeField] private bool canMoveWorld;
    [SerializeField, Range(-100, -1)] private float worldMoveSpeed = -5f;

    private void Update()
    {
        MoveWorld();
    }

    void MoveWorld()
    {
        if (!canMoveWorld) return;
        transform.position += new Vector3(worldMoveSpeed * Time.deltaTime, 0, 0);
    }
}
