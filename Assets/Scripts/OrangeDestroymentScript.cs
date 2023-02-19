using Assets.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OrangeDestroymentScript : MonoBehaviour
{
    StartGameScript _startGameScript;

    UpdateDataOnScreenScript _updateDataOnScreenScript;

    Canvas _gameOverCanvas;

    OrangeSpawningScript _orangeSpawningScript;

    [SerializeField]
    Animator _hurtingAnimator;

    // Start is called before the first frame update
    void Start()
    {
        _startGameScript = SceneManager.GetActiveScene().GetRootGameObjects().
            Where(x => x.gameObject.name == "ScriptHolder")
            .FirstOrDefault().GetComponentInChildren<StartGameScript>();

        _updateDataOnScreenScript = SceneManager.GetActiveScene().GetRootGameObjects().
            Where(x => x.gameObject.name == "ScriptHolder")
            .FirstOrDefault().GetComponentInChildren<UpdateDataOnScreenScript>();

        _orangeSpawningScript = SceneManager.GetActiveScene().GetRootGameObjects().
            Where(x => x.gameObject.name == "SpawnPoints")
            .FirstOrDefault().GetComponentInChildren<OrangeSpawningScript>();

        _hurtingAnimator= SceneManager.GetActiveScene().GetRootGameObjects().
            Where(x => x.gameObject.name == "Canvas").FirstOrDefault().GetComponentInChildren<Animator>();

        _gameOverCanvas = SceneManager.GetActiveScene().
            GetRootGameObjects().Where(x => x.gameObject.name == "RestartGameCanvas").FirstOrDefault().GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "basket")
        {
            Destroy(gameObject);
            _startGameScript.game.gainedOranges++;
            _updateDataOnScreenScript.UpdateData();
            _orangeSpawningScript.IncreaseSpawningSpeed();
        }
        if(collision.gameObject.name == "BottomBorder")
        {
            Destroy(gameObject);

            _startGameScript.game.lifeCount--;

            if(_startGameScript.game.lifeCount <= 0) 
            {
                Time.timeScale = 0f;
                _gameOverCanvas.gameObject.SetActive(true);
            }

            _hurtingAnimator.SetTrigger("BallMissed");


            _updateDataOnScreenScript.UpdateData();
        }
    }
}
