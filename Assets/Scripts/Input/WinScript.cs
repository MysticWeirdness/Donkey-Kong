using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Here");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
}
