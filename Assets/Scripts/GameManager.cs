using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //singleton stuff
    private static GameManager _instance = null;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    public static GameManager instance()
    {
        return _instance;
    }
    
    //Other stuff

    private Player player;
    public Canvas deathCanvas;
    public TMP_Text healthText;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        player.reset();
        deathCanvas.gameObject.SetActive(false);
    }

    public void updateHealth(int health)
    {
        healthText.text = "x" + health;
    }

    public void deathCanvasSwitch()
    {
        if (deathCanvas.gameObject.activeSelf == true)
        {
            deathCanvas.gameObject.SetActive(false);
        }
        else
        {
            deathCanvas.gameObject.SetActive(true);
        }
    }

    public void onResetClick()
    {
        player.reset();
        deathCanvas.gameObject.SetActive(false);
    }

    public void onMenuClick()
    {
        //return us to the main menu
        SceneManager.LoadScene("Menu");
    }
}
