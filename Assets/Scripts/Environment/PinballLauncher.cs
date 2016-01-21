using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;


namespace Assets.Scripts.Environment {

    public class PinballLauncher : MonoBehaviour {

        // Delegates for the size of the queue changing
        public delegate void DQueueChange( ReadOnlyCollection<Rigidbody> newQueue );

        [ Tooltip( "Depending on how long the launcher has been charging it will multiply the ForceValue by this." ) ] public AnimationCurve ForceMultipler = AnimationCurve.Linear( 0.0f, 0.0f, 1.0f, 1.0f );

        public float MinForce = 1.0f;
        public float MaxForce = 5.0f;

        [ Tooltip( "How many seconds the launcher must charge until it is at full ForceMultipler." ) ] public float
            MaxForceTime = 1.0f;

        public DQueueChange OnQueueChange;

        public bool Charging = false;

        private float m_timeSpentCharging = 0.0f;

        // Queue of balls to fire
        private List<Rigidbody> m_ballQueue = new List<Rigidbody>();

        public ReadOnlyCollection<Rigidbody> BallQueue { get { return m_ballQueue.AsReadOnly(); } }

        // Func to add a ball to the queue
        public void AddBallToQueue( Rigidbody ball ) {
            ball.gameObject.SetActive( false );
            m_ballQueue.Add( ball );
            if ( OnQueueChange != null ) { OnQueueChange( m_ballQueue.AsReadOnly() ); }
        }

        private float GetChargedForce() {
            // Unclamped in case you want the ForceMultiplier to be a larger range than 0-1.
            return Mathf.LerpUnclamped( MinForce,
                                        MaxForce,
                                        ForceMultipler.Evaluate( m_timeSpentCharging / MaxForceTime ) );
        }

        // Func to get the next ball to fire
        private Rigidbody GetNextBall() {
            if ( m_ballQueue.Count == 0 ) {
                return null;
            }
            Rigidbody ball = m_ballQueue[0];
            m_ballQueue.RemoveAt( 0 );
            ball.gameObject.SetActive( true );
            if ( OnQueueChange != null ) { OnQueueChange( m_ballQueue.AsReadOnly() ); }
            return ball;
        }

        // Func to launch the ball out
        private Rigidbody LaunchNextBall() {
            Rigidbody ball = GetNextBall();
            if ( ball == null ) { return null; }
            ball.transform.position = transform.position + transform.up;
            ball.transform.rotation = Quaternion.identity;
            ball.AddForce( transform.up * GetChargedForce(), ForceMode.VelocityChange );
            return ball;
        }

        private void LogQueueChange( ReadOnlyCollection<Rigidbody> newQueue ) {
            Debug.LogFormat( "#{0}# You have {1} balls remaining.", GetType().Name, newQueue.Count );
        }

        private void Start() { OnQueueChange += LogQueueChange; }

        private void Update() {
            if ( Charging ) {
                m_timeSpentCharging += Time.deltaTime;
            }
            else if ( !Mathf.Approximately( m_timeSpentCharging, 0.0f ) ) {
                LaunchNextBall();
                m_timeSpentCharging = 0.0f;
            }
        }

    }

}
