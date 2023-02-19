using Assets.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameScript : MonoBehaviour
{
    public Game game;
    [SerializeField]
    UpdateDataOnScreenScript _updateDataOnScreenScript;
    // Start is called before the first frame update
    void Awake()
    {
        game = new Game();
    }

    private void Start()
    {
        _updateDataOnScreenScript.UpdateData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
