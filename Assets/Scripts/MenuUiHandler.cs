using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif


// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]
public class MenuUiHandler : MonoBehaviour
{

    public Text BestScoreText;
    private string currentPlayerName;

    // Start is called before the first frame update
    void Start()
    {
        NameTransfer.Instance.LoadBest();
        BestScoreText.text = NameTransfer.Instance.bestName + " : " + NameTransfer.Instance.bestScore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetPlayerName(string Input)
    {
        currentPlayerName = Input;
        NameTransfer.Instance.currentPlayerName = Input;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();

#else
     Application.Quit();

#endif

    }

   public void ResetBestScore()
    {
        NameTransfer.Instance.bestName = "";
        NameTransfer.Instance.bestScore = 0;
        NameTransfer.Instance.SaveBest();
        BestScoreText.text = NameTransfer.Instance.bestName + " : " + NameTransfer.Instance.bestScore;
    }
}
