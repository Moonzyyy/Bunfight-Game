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

        private string _publicLeaderboardKey = "8bb54f1b56c597eb04b269e7e74c6c8a928a0acc05dac5e222e63235ac1e122d";

        private string _privateLeaderboardKey =
            "38ed50a2a3e395f29a292c9a8b4d208189314e8f856a7873b809d40ff4f55597a495cfa9d121d8111503595c015d21ac585dba5b3ae176b5ad3d3c3433bddad2b9db17b03c66736004476d2097fa1b31b7c7305552b1844732dec3554f39fb68b317c336245c0948bdec3865737c89bdb17e27fcf41f08b0754619641874489c";

        private bool _canUploadEntry = true;

        private void OnEnable()
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
                LeaderboardCreator.ResetPlayer();
                GetLeaderboard();
            }));   
        }
    }
}

