using System.Collections.Generic;
using Obstacles;
using UnityEngine;


namespace Assets.Scripts {

    [RequireComponent( typeof( HingeJoint ) )]
    public class FlipperController : MonoBehaviour, IObstacle {

        public int torqueValue = 500;

        public string InputBind = SRInput.Jump;

        public float activeAngle = 35;
        public float passiveAngle = -35;

        private HingeJoint hj;
        private bool m_isObjectEnabled;

        // Update is called once per frame
        void FixedUpdate( ) { Swing( Input.GetButton( InputBind ) ? activeAngle : passiveAngle, torqueValue ); }

        // Use this for initialization
        void Start( ) { hj = GetComponent<HingeJoint>( ); }

        void Swing( float angle, float force ) {
            hj.spring = new JointSpring { spring = force, targetPosition = angle, damper = hj.spring.damper };
        }

        public bool IsObjectEnabled { get { return gameObject.activeSelf; } set { gameObject.SetActive( value ); } }

        private DOnHit m_onHit;
        public event DOnHit OnHit { add { m_onHit += value; } remove { m_onHit -= value; } };

        public void OnCollisionEnter( Collision collision ) {
            if ( m_onHit != null ) {
                m_onHit( this );
            }
        }

    }

}
