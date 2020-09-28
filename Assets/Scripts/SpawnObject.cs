using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;
    [SerializeField] private DataTable_WaveData[] waveData;
    private bool _waveReady = true;
    private int currentWave = -1;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && _waveReady)
        {
            _waveReady = false;
            currentWave++;
            if (currentWave >= waveData.Length)
            {
                currentWave = 0;
            }
            StartCoroutine(Spawn());
        }
    }
    IEnumerator Spawn()
    {
        int index = 0;
        while (index < waveData[currentWave]._health.Length)
        {
            var newGameObject = Instantiate(_gameObject, this.transform.position, Quaternion.identity);
            newGameObject.GetComponent<Path>().checkpoints = this.GetComponent<Path>().checkpoints;
            newGameObject.GetComponent<EnemyHealth>()._health = waveData[currentWave]._health[index];
            index++;
            yield return new WaitForSeconds(waveData[currentWave]._delay);
        }
        _waveReady = true;
    }
}
