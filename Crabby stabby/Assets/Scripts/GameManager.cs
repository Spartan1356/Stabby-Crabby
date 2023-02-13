using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public void EndGame ()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
        Debug.Log("POOTIS");
            GameOver();
        }

    }

    void GameOver()
    {
        SceneManager.LoadScene("GameEnd");
    }

}
