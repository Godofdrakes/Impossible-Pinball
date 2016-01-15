using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts {

    [ RequireComponent( typeof( Text ) ) ]
    public class ScoreDisplay : MonoBehaviour {

        public delegate void DOnScoreChanged( int score );

        private Text m_scoreText = null;

        private int m_score = -1;

        private DOnScoreChanged m_onScoreChanged;

        public int Score {
            get { return m_score; }
            set {
                if ( m_score == value ) { return; }
                m_score = value;
                if ( m_onScoreChanged != null ) {
                    m_onScoreChanged( m_score );
                }
            }
        }

        public static void AddScore( int value ) {
            ScoreDisplay scoreDisplay = FindObjectOfType<ScoreDisplay>();
            if ( scoreDisplay != null ) {
                scoreDisplay.Score += value;
            }
        }

        public void OnDestroy() { OnScoreChanged -= UpdateScoreText; }

        public event DOnScoreChanged OnScoreChanged {
            add { m_onScoreChanged += value; }
            remove { if ( m_onScoreChanged != null ) { m_onScoreChanged -= value; } }
        }

        private void Start() {
            m_scoreText = GetComponent<Text>();
            OnScoreChanged += UpdateScoreText;
            Score = 0;
        }

        private void UpdateScoreText( int score ) { m_scoreText.text = string.Format( "Score: {0}", Score ); }

    }

}
