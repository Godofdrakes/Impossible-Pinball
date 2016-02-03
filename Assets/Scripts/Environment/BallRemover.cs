using System.Collections.Generic;
using System.Linq;
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

            int ballsInLauncher = 0;
            if ( PlayerControlledLauncher.MainLauncher == null ) {
                this.LogWarning( "PlayerControlledLauncher.MainLauncher == null" );
            }
            else {
                ballsInLauncher = PlayerControlledLauncher.MainLauncher.PinballLauncher.BallQueue.Count;
            }

            int ballsInPlay =
                FindObjectsOfType<Rigidbody>()
                    .Count( body => body.tag == SRTags.Ball && body != other.attachedRigidbody );

            if ( ballsInLauncher < 1 &&
                 ballsInPlay < 1 ) {
                GameOverPopup.ShowGameOver();
            }
        }

    }

}
