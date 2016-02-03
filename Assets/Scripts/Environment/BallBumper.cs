using System.Collections.Generic;
using Obstacles;
using UnityEngine;


namespace Assets.Scripts.Environment {

    [ RequireComponent( typeof( MeshRenderer ), typeof( Collider ) ) ]
    public class BallBumper : MonoBehaviour, IObstacle {

        [ Range( 0, 3 ) ] public float BumperForce;

        [ Tooltip( "After this many hits the object will disable itself. Less than 0 is infinite health." ) ] public int
            m_health = -1;

        private MeshRenderer m_meshRenderer = null;
        private Collider m_collider = null;

        private DOnHit m_onHit;

        private bool m_isObjectEnabled = true;

        public int Health {
            get { return m_health; }
            set {
                m_health = value;
                IsObjectEnabled = m_health != 0;
            }
        }

        [SerializeField] private int m_initialHealth = -1;

        [SerializeField] private int m_pointValue = 0;

        public void OnCollisionEnter( Collision collision ) {
            collision.rigidbody.AddForce( -1 * collision.contacts[0].normal * BumperForce, ForceMode.Impulse );
            ScoreDisplay.AddScore(m_pointValue);
            if ( Health > 0 ) {
                --Health;
            }
            if ( m_onHit != null ) {
                m_onHit( this );
                
            }
        }

        private void OnDisable() { IsObjectEnabled = false; }

        private void OnEnable() {
            m_collider = GetComponent<Collider>();
            m_meshRenderer = GetComponent<MeshRenderer>();
            IsObjectEnabled = true;
            Health = m_initialHealth;
        }

        public bool IsObjectEnabled {
            get { return m_isObjectEnabled; }
            set {
                m_isObjectEnabled = value;
                m_meshRenderer.enabled = m_isObjectEnabled;
                m_collider.enabled = m_isObjectEnabled;
            }
        }

        public void Reset()
        {
            Health = m_initialHealth;
            IsObjectEnabled = true;
            m_onHit(this);
        }

        public event DOnHit OnHit { add { m_onHit += value; } remove { m_onHit -= value; } }

    }

}
