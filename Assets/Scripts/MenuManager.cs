using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void onPlayClick()
    {
        //switch the main game scene
        SceneManager.LoadScene("MainGame");
    }
}
