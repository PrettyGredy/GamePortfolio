using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _victoryScreen;
    [SerializeField] private GameObject _lossScreen;
    [SerializeField] private Button _backMenuButton;
    [SerializeField] private PlayerProfile _playerProfile;

    private void OnEnable()
    {
        _player.Dying += LossScreenEnabled;
        _player.Victoring += VictoryScreenEnabled;
        _backMenuButton.onClick.AddListener(OnBackMenuButtonClicl);
    }

    private void OnDisable()
    {
        _player.Dying -= LossScreenEnabled;
        _player.Victoring -= VictoryScreenEnabled;
        _backMenuButton.onClick.RemoveListener(OnBackMenuButtonClicl);
    }

    private void VictoryScreenEnabled()
    {
        _playerProfile.Save(1,0);
        Cursor.lockState = CursorLockMode.None;
        _backMenuButton.gameObject.SetActive(true);
        _victoryScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void LossScreenEnabled()
    {
        _playerProfile.Save(0,1);
        Cursor.lockState = CursorLockMode.None;
        _backMenuButton.gameObject.SetActive(true);
        _lossScreen.SetActive(true);
        Time.timeScale = 0;
    }

    private void OnBackMenuButtonClicl()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
