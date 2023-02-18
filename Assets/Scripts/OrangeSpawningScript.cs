using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSpawningScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D _orangePrefab;
    private const int cooldownDefaultTime = 5;

    private void Start()
    {
        StartCoroutine(Spawn());
    }


    private void Update()
    {

    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(cooldownDefaultTime);

        var indexOfSpawnPoint = Random.Range(0, 4);

        var spawnPoint = gameObject.transform;

        if(gameObject.transform.childCount == 4 ) 
        {

        }
        spawnPoint = gameObject.transform.GetChild(indexOfSpawnPoint);

        Instantiate(_orangePrefab, spawnPoint);
        yield return StartCoroutine(Spawn());
    }
}
