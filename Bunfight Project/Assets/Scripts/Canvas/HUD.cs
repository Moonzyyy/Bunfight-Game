using Player;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    PlayerStats _playerStats;
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = _playerStats.score.ToString();
    }
}
