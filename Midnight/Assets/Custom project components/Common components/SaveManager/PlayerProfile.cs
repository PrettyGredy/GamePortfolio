using UnityEngine;

public class PlayerProfile : MonoBehaviour
{
    [SerializeField] private Player _player;

    private const string _saveKey = "mainSave";

    private int _victoryCount;
    private int _lossesCount;

    public int VictoryCount => _victoryCount;
    public int LossCount => _lossesCount;

    private void Start()
    {
        Load();
    }

    public void Load()
    {
        var data = SaveManager.LoadingProgress<SaveData.PlayerProfileData>(_saveKey);
        _victoryCount = data.VictoryCountProfile;
        _lossesCount = data.LossesCountProfile;
    }

    public void Save(int victory, int loss)
    {
        SaveManager.SavingProgress(_saveKey, GetSaveSnapshot(victory, loss));
    }

    private SaveData.PlayerProfileData GetSaveSnapshot(int victory, int loss)
    {
        var data = new SaveData.PlayerProfileData();
        {
            data.VictoryCountProfile = _victoryCount + victory;
            data.LossesCountProfile = _lossesCount + loss;
        }

        return data;
    }
}
