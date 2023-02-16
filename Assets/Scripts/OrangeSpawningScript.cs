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
        Instantiate(_orangePrefab, gameObject.transform.GetChild(Random.Range(0, 4)));
        yield return StartCoroutine(Spawn());
    }
}
