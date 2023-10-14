using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Threading;


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
        Debug.Log(GameManager.instance);
        GameManager.instance.LoadUserData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //call end edit
    public void GetPlayerName(){
        GameManager.instance.playerName = inputField.text;
        InitializeInputField();
    }

    private void InitializeInputField(){
        inputField.text = "";
        inputFieldObj.SetActive(false);
    }

    public void LoadMainScene(){
        StartCoroutine(nameof(CountDown));
        SceneManager.LoadScene(1);
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
    }
}
