using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif


public class Title : MonoBehaviour
{
    [SerializeField]
    private GameObject inputFieldObj;

    [SerializeField]
    private TextMeshProUGUI countDownText;
    private TMP_InputField inputField;
    private int timer = 3;


    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("InputField").GetComponent<TMP_InputField>();
        //Debug.Log(GameManager.instance);
    }

    // Update is called once per frame

    //call selected
    public void SetPlayerName(){
        Debug.Log(GameManager.instance.playerName);
        inputField.text = GameManager.instance.playerName;
    }
    

    //call end edit
    public void GetPlayerName(){
        GameManager.instance.playerName = inputField.text;
        Debug.Log(GameManager.instance.playerName);
        InitializeInputField();
    }

    private void InitializeInputField(){
        inputField.text = "";
        inputFieldObj.SetActive(false);
    }

    public void LoadMainScene(){
        StartCoroutine(nameof(CountDown));
    }

    IEnumerator CountDown(){
        countDownText.enabled = true;

        for(int i = 0; i < timer; i++){
            if((timer - i) > 1){
                countDownText.text = "After " + (timer - i).ToString() + " seconds, Load Main Scene.";
            }
            else{
                countDownText.text = "After " + (timer - i).ToString() + " second, Load Main Scene.";
            }
            yield return new WaitForSeconds(1.0f);
        }

        SceneManager.LoadScene(1);
    }

    public void Exit(){
        GameManager.instance.SaveUserData();
        Debug.Log("exit");
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
        Application.Quit();
        #endif
    }
}
