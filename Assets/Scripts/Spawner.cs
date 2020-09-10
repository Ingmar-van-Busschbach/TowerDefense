using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject SpawnObject;
    [SerializeField] private bool SpawnActive;
    private int timer = 0;
    private Vector3 _spawnPosition;
    private GameObject[] _spawnArray;
    // Start is called before the first frame update
    void Start()
    {

        _spawnArray = GameObject.FindGameObjectsWithTag("Spawner");

        timer = Random.Range(1, 5);

        if (SpawnActive == true)
        {
            StartCoroutine(Spawn());
        }
    }

    // Update is called once per frame
    private IEnumerator Spawn()
    {
        _spawnPosition = _spawnArray[Random.Range(0, _spawnArray.Length)].transform.position;
        yield return new WaitForSeconds(timer);

        StartCoroutine(Spawn());

        timer = Random.Range(1, 5);
        Instantiate(SpawnObject, new Vector3(_spawnPosition.x, _spawnPosition.y, _spawnPosition.z), Quaternion.identity);
    }
}
