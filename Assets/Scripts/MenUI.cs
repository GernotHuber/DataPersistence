using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenUI : MonoBehaviour
{
    public TMP_InputField nameText;
    public TMP_Text bestScore;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.bestName!=null)
        {
            bestScore.text = "Best Score:" + GameManager.Instance.bestScore + " " + GameManager.Instance.bestName;
        }
    }
    public void StartNew()
    {
        if(nameText!=null)
        {
            GameManager.Instance.playerName = nameText.text;
        }

        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        GameManager.Instance.SaveGame();
        //GameManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}
