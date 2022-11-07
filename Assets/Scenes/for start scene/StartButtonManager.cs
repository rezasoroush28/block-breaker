using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtonManager : MonoBehaviour
{

    public void ChangeToMainGame()
    {
        SceneManager.LoadScene("Main Game");
    }
}
