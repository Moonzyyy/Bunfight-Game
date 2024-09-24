using Player;
using TMPro;

namespace GameManager
{
    using UnityEngine;
    using UnityEngine.Events;   
    public class ScoreManager : MonoBehaviour
    {
        PlayerStats _playerStats;
        private int _score;
        
        public UnityEvent<string, int> submitScoreEvent;
        [SerializeField] private TMP_InputField nameField;
        // Start is called before the first frame update
        void Start()
        {
            _playerStats = FindObjectOfType<PlayerStats>();
            _score = _playerStats.score;
        }

        public void SubmitScore()
        {
            if (nameField.text.Length == 0) return;
            submitScoreEvent.Invoke(nameField.text, _score);
            nameField.text = "";
        }
    }

}
