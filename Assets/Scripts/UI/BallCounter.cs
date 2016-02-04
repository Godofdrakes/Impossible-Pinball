using System.Collections.Generic;
using System.Collections.ObjectModel;
using Assets.Scripts.Environment;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts.UI {

    [ RequireComponent( typeof( Text ) ) ]
    public class BallCounter : MonoBehaviour {

        private Text m_text = null;

        private PinballLauncher m_pinballLauncher = null;

        private PinballLauncher PinballLauncher {
            set {
                if ( m_pinballLauncher != null &&
                     m_pinballLauncher.OnQueueChange != null ) {
                    m_pinballLauncher.OnQueueChange -= OnQueueChange;
                }
                m_pinballLauncher = value;
                if ( m_pinballLauncher != null ) {
                    m_pinballLauncher.OnQueueChange += OnQueueChange;
                }
            }
            get { return m_pinballLauncher; }
        }

        private void OnDisable() { PinballLauncher = null; }

        private void OnEnable() {
            foreach ( PinballLauncher launcher in FindObjectsOfType<PinballLauncher>() ) {
                if ( launcher.tag == SRTags.Main_Ball_Launcher ) {
                    PinballLauncher = launcher;
                    break;
                }
            }
            m_text = GetComponent<Text>();
            if ( PinballLauncher != null ) {
                OnQueueChange( PinballLauncher.BallQueue );
            }
        }

        private void OnQueueChange( ReadOnlyCollection<Rigidbody> newQueue ) {
            m_text.text = string.Format( "Balls Remaining: {0}", newQueue.Count );
        }

    }

}
