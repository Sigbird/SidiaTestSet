using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject CreditsPanel;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuButtons(int bt)
    {
        switch (bt)
        {
            case 1:
                SceneManager.LoadScene("Game");
                break;
            case 2:
                CreditsPanel.SetActive(true);
                break;
            case 3:
                Application.Quit();
                break;
        }
    }
}
