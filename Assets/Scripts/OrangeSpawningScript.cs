using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSpawningScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D _orangePrefab;

    private const float cooldownDefaultTime = 5;

    private float coolDownTime = cooldownDefaultTime;

    private void Start()
    {
        StartCoroutine(Spawn());
    }


    private void Update()
    {

    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(coolDownTime);

        var indexOfSpawnPoint = Random.Range(0, 4);

        var spawnPoint = gameObject.transform;

        spawnPoint = gameObject.transform.GetChild(indexOfSpawnPoint);

        Instantiate(_orangePrefab, spawnPoint);
        yield return StartCoroutine(Spawn());
    }

    public void IncreaseSpawningSpeed()
    {
        coolDownTime -=  0.05f;
    }
}
