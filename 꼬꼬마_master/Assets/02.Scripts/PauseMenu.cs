using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField]
    private GameObject go_BaseUi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!PlayerController.Player_Convert)
            {
                CallMenu();
            }
            else {
                CloseMenu();
            }

        }
        
    }


    private void CallMenu()
    {
        go_BaseUi.SetActive(true);
        Time.timeScale = 0f;
    }

    private void CloseMenu()
    {
        go_BaseUi.SetActive(false);
        Time.timeScale = 1f;

    }

    public void ClickExit()
    {
        Debug.Log("게임종료");
        Application.Quit();

    }


}
