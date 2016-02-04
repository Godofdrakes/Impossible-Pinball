using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameUI : MonoBehaviour {

    public void ExitGame() { Application.Quit(); }

    public void StartNewGame() { SceneManager.LoadScene( 1 ); }

}
