using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDataOnScreenScript : MonoBehaviour
{
    [SerializeField]
    Text _textWithScore;
    [SerializeField]
    Transform _transformWithHealth;
    [SerializeField]
    GameObject _heartPrefab;

    [SerializeField]
    StartGameScript _startGameScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateData()
    {
        _textWithScore.text = _startGameScript.game.gainedOranges.ToString();
        UpdateHealthOnDisplay();
    }

    private void UpdateHealthOnDisplay()
    {
        ClearPanel();

        for(int i =0; i < _startGameScript.game.lifeCount; ++i) 
        {
            var heart = Instantiate(_heartPrefab, _transformWithHealth);
        }
    }

    public void ClearPanel()
    {
        foreach (Image child in _transformWithHealth.GetComponentsInChildren<Image>())
        {
            Destroy(child.gameObject);
        }
    }
}
