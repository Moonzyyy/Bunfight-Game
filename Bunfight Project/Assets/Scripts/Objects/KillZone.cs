using System;
using Player;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    PlayerStats _playerStats;
    [SerializeField, Range(1, 10)] private int scoreToReduce;
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = FindObjectOfType<PlayerStats>();
    }
}
