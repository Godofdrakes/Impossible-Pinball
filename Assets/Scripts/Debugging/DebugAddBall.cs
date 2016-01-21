using System.Collections.Generic;
using Assets.Scripts.Environment;
using UnityEngine;


namespace Assets.Scripts.Debugging {

    [ RequireComponent( typeof( PinballLauncher ) ) ]
    public class DebugAddBall : MonoBehaviour {

        public Rigidbody DebugBall = null;

        private PinballLauncher m_pinballLauncher = null;

        private void OnEnable() {
            if ( !Application.isEditor ) {
                Destroy( this ); // Removes this script from the gameObject
                return;
            }
            m_pinballLauncher = GetComponent<PinballLauncher>();
        }

        private void Update() {
            if ( Input.GetKeyDown( KeyCode.Keypad1 ) ) {
                m_pinballLauncher.AddBallToQueue( Instantiate( DebugBall ) );
            }
            else if ( Input.GetKeyDown( KeyCode.Keypad9 ) ) {
                for ( int n = 0; n < 9; n++ ) {
                    m_pinballLauncher.AddBallToQueue( Instantiate( DebugBall ) );
                }
            }
        }

    }

}
