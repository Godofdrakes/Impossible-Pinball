using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


namespace Assets.Scripts.UI {

    public class GameOverPopup : MonoBehaviour {

        public void Exit() { Application.Quit(); }

        public void MainMenu() { SceneManager.LoadScene( "Menu" ); }

        public void Restart() { SceneManager.LoadScene( SceneManager.GetActiveScene().name ); }

        public static void ShowGameOver() {
            GameOverPopup popup = FindObjectOfType<GameOverPopup>();
            popup.GetComponent<Image>().enabled = true;
            popup.transform.GetChild( 0 ).gameObject.SetActive( true );
        }

    }

}
