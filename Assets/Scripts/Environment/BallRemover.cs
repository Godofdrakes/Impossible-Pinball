using System.Collections.Generic;
using Assets.Scripts.UI;
using UnityEngine;


namespace Assets.Scripts.Environment {

    [ RequireComponent( typeof( Collider ) ) ]
    public class BallRemover : MonoBehaviour {

        public void OnTriggerEnter( Collider other ) {
            if ( other.tag == SRTags.Ball ) {
                other.gameObject.SetActive( false );
                Destroy( other.gameObject );
            }

            // Game Over Check
            PlayerControlledLauncher launcher =
                GameObject.FindGameObjectWithTag( SRTags.Main_Ball_Launcher ).GetComponent<PlayerControlledLauncher>();
            this.LogMessage( string.Format( "Balls in launcher: {1}. Balls in play: {0}.",
                                            launcher.PinballLauncher.BallQueue.Count,
                                            GameObject.FindGameObjectsWithTag( SRTags.Ball ).Length ) );
            if ( launcher &&
                 launcher.PinballLauncher.BallQueue.Count < 1 &&
                 GameObject.FindGameObjectsWithTag( SRTags.Ball ).Length < 1 ) {
                // GameObject.FindGameObjectsWithTag( SRTags.Ball ).Length <= 1 because the ball isn't actually deleted until AFTER this code is run.
                GameOverPopup.ShowGameOver();
            }
        }

    }

}
