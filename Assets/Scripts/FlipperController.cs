using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Obstacles;
using UnityEngine;


namespace Assets.Scripts {

    [RequireComponent( typeof( HingeJoint ) )]
    [RequireComponent(typeof(AudioSource))]
    public class FlipperController : MonoBehaviour, IObstacle
    {

        public int torqueValue = 500;

        public string InputBind;
        public float activeAngle = 35;
        public float passiveAngle = -35;

        private HingeJoint hj;
        private bool m_isObjectEnabled;
        private AudioSource m_swingAudioSource;

        // Update is called once per frame
        void FixedUpdate()
        {
            if (Input.GetButtonDown(InputBind))
            {
                m_swingAudioSource.Play();
            }
            Swing( Input.GetButton( InputBind ) ? activeAngle : passiveAngle, torqueValue );
        }

        // Use this for initialization
        void Start()
        {
            hj = GetComponent<HingeJoint>( );
            m_swingAudioSource = GetComponent<AudioSource>();
            
        }

        void Swing( float angle, float force ) {
            hj.spring = new JointSpring { spring = force, targetPosition = angle, damper = hj.spring.damper };
        }

        public bool IsObjectEnabled { get { return gameObject.activeSelf; } set { gameObject.SetActive( value ); } }

        private DOnHit m_onHit;
        public event DOnHit OnHit { add { m_onHit += value; } remove { m_onHit -= value; } }

        public void OnCollisionEnter( Collision collision ) {
            if ( m_onHit != null ) {
                m_onHit( this );
            }
        }
    }

}
