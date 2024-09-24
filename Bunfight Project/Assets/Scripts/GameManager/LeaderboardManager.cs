namespace GameManager
{
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
    using Dan.Main;

    public class LeaderboardManager : MonoBehaviour
    {
        [SerializeField] List<TextMeshProUGUI> names;
        [SerializeField] List<TextMeshProUGUI> score;

        private string _publicLeaderboardKey = "1d7196b222715798082f821de191d1b99b7646a16d03fdc8ba858b5ff496d010";

        private bool _canUploadEntry = true;

        private void Start()
        {
            GetLeaderboard();
        }

        public void GetLeaderboard()
        {
            LeaderboardCreator.GetLeaderboard(_publicLeaderboardKey, ((msg) =>
            {
                int messageLength = (msg.Length < names.Count) ? msg.Length : names.Count;
                for (int i = 0; i < messageLength; i++)
                {
                    names[i].text = msg[i].Username;
                    score[i].text = msg[i].Score.ToString();
                }
            }));
        }

        public void AddLeaderboardEntry(string username, int userScore)
        {
            if (!_canUploadEntry) return;
            LeaderboardCreator.UploadNewEntry(_publicLeaderboardKey, username, userScore, ((msg) =>
            {
                GetLeaderboard();
                _canUploadEntry = false;
            }));   
        }
    }
}

