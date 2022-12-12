using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMoney : MonoBehaviour
{
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private Coin _coin;
    [SerializeField] private float _timeBetweenSpawn;

    private void Start()
    {
        StartCoroutine(AppearMoney());
    }

    private IEnumerator AppearMoney()
    {
        var timeBetweenSpawn = new WaitForSeconds(_timeBetweenSpawn);

        while (true)
        {
            int spawnPointNumber = Random.Range(0, _spawnPoints.Length);

            Instantiate(_coin, _spawnPoints[spawnPointNumber]);

            yield return timeBetweenSpawn;
        }
    }
}
