using System.Collections.Generic;
using System.Linq;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private List<Transform> _spawnPoints;
    [SerializeField] float _delayBetweenWave;

    private Wave _currentWave;
    private int _currentWaveNumber;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private float _timeBetweenWaves;

    public event UnityAction<int, int> EnemyCountChanged;
    public event UnityAction<int, int> WaveCountChanged;

    public int TotalEnemySpawned { get; private set; }

    private void Start()
    {
        SetWave(_currentWaveNumber);
        TotalEnemies();
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay && _spawned <=_currentWave.Count - 1)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
            EnemyCountChanged?.Invoke(_spawned, _currentWave.Count);
            
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber + 1)
            {
                _timeBetweenWaves += Time.deltaTime;
            }

            _currentWave = null;
        }

        if (_timeBetweenWaves >= _delayBetweenWave)
        {
            NextWave();
            _timeBetweenWaves = 0;
        }
    }

    private void InstantiateEnemy()
    {
        int spawnPointNumber = Random.Range(0, _spawnPoints.Count-1);

        Enemy enemy = Instantiate(_currentWave.Template, _spawnPoints[spawnPointNumber].position, _spawnPoints[spawnPointNumber].rotation, _spawnPoints[spawnPointNumber]).GetComponent<Enemy>();
        enemy.Init(_player);
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
        EnemyCountChanged?.Invoke(0, 1);
        WaveCountChanged?.Invoke(index+1, _waves.Count);
    }

    private void NextWave()
    {
        _currentWaveNumber++;
        SetWave(_currentWaveNumber);
        WaveCountChanged?.Invoke(_currentWaveNumber+1, _waves.Count);
        _spawned = 0;
    }

    private void TotalEnemies()
    {
        foreach (var wave in _waves)
        {
            TotalEnemySpawned += wave.Count;
        }
    }
}

[System.Serializable]
public class Wave
{
    public GameObject Template;
    public float Delay;
    public int Count;
}
