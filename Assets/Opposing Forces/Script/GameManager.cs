using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    void Update()
    {
        //Loads the scene again once player presses P
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene("OpposingForcesScene");
        }
    }
}