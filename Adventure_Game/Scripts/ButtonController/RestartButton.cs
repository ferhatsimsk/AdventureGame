using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Level001"); // Y�klenecek sahne ad�
    }
}
