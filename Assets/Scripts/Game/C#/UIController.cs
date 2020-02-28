using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    // Start is called before the first frame update
    public Scrollbar LifeBar;
    public Text ScoreText;

    private void Awake()
    {
       
        GameMasterScript.uiController = this.gameObject.GetComponent<UIController>();
    }
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
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;
            case 2:
                SceneManager.LoadScene("MainMenu");
                break;
        }
    }
}
