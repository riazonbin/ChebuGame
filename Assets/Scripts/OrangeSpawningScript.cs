using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrangeSpawningScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D _orangePrefab;
    float time = 5;
    public void Spawn()
    {
    }
    private void Update()
    {
        time = time - Time.deltaTime;
        if (time < 0)
        {
            Instantiate(_orangePrefab, gameObject.transform.GetChild(Random.Range(0, 4)));
            time = 5;
        }
    }
}
