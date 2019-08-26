using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class buttonI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.SetResolution(1280, 720, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("IHT");
    }
}
