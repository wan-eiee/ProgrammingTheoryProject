using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MainManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI welcomeText;


    // Start is called before the first frame update
    void Start()
    {
        welcomeText.text = "Welcome, " + GameManager.instance.playerName + "!";
        GameManager.instance.SaveUserData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadMenuScene(){
        SceneManager.LoadScene(0);
    }
}
