using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
        
            SceneManager.LoadScene("game");
        }
    }

    private void OnGUI()
    {
    
        GUIStyle style = new GUIStyle();
        style.fontSize = 40;
        style.normal.textColor = Color.white;

  
        float width = style.CalcSize(new GUIContent("Press Space to Start")).x;
        float height = style.CalcSize(new GUIContent("Press Space to Start")).y;
        Rect textRect = new Rect(Screen.width / 2 - width / 2, Screen.height / 2 - height / 2, width, height);

  
        GUI.Label(textRect, "Press Space to Start", style);
    }
}

