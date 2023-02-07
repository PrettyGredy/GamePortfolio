using TMPro;
using UnityEngine;

public class ScoreHomeScreen : MonoBehaviour
{
    [SerializeField] private TMP_Text _victory;
    [SerializeField] private TMP_Text _loss;
    [SerializeField] private PlayerProfile _PlayerProfile;

    private void Start()
    {
        _PlayerProfile.Load();
        DisplayScoreOnHomeScreen(_PlayerProfile.VictoryCount, _PlayerProfile.LossCount);
    }

    private void DisplayScoreOnHomeScreen(int victory, int loss)
    {
        _victory.text = victory.ToString();
        _loss.text = loss.ToString();
    }
}
