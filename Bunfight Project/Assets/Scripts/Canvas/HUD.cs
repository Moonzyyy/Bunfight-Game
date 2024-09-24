using Player;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] GameObject resetButton;
    PlayerStats _playerStats;

    public bool canResetGameUsingButton;
    // Start is called before the first frame update
    void Start()
    {
        _playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        if (canResetGameUsingButton)
        {
            resetButton.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = _playerStats.score.ToString();
    }

    public void DisableScoreText()
    {
        scoreText.gameObject.SetActive(false);
    }
}
