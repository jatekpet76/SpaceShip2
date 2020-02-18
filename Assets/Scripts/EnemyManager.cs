using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _shipPrefabs;

    [SerializeField]
    private int _idleSecs = 5;

    // Start is called before the first frame update
    void Start()
    {
        var coroutine = spawnShips();
        StartCoroutine(coroutine);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnShips()
    {
        while (true)
        {
            spawnRandomShip();

            yield return new WaitForSeconds(_idleSecs);
        }
    }

    private void spawnRandomShip()
    {
        var shipPos = Random.Range(0, _shipPrefabs.Length);

        Instantiate(_shipPrefabs[shipPos], new Vector3(Random.Range(-9, 9), 6f, -2f), Quaternion.identity);
    }
}
