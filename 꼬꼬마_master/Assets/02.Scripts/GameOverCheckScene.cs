using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverCheckScene : MonoBehaviour
{
    public static int GameOverCheck = 0;

    public Image ScaryOverImage;
    // Start is called before the first frame update
    void Start()
    {
        ScaryOverImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOverCheck == 1)
        {
            ScaryOverImage.gameObject.SetActive(true);
            Invoke("GameOver", 0.5f);
            GameOverCheck = 3;
        }
        else if(GameOverCheck == 2)
        {
            Invoke("GameClear", 0.5f);
            GameOverCheck = 3;
        }
    }

    void GameOver()
    {
        Debug.Log("DEAD");
        SceneManager.LoadScene("GameOver");
    }

    void GameClear()
    {
        SceneManager.LoadScene("GameClear");
    }
}
