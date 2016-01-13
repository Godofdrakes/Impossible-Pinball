using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts {

    public class BallLauncher : MonoBehaviour {

        public Rigidbody BallPrefab = null;

        public Vector3 BallStartOffset = Vector3.forward;

        [ Range( 1.0f, 100.0f ) ] public float MinForce = 1.0f;

        [ Range( 1.0f, 100.0f ) ] public float MaxForce = 5.0f;

        [ Range( 0.01f, 5.0f ) ] public float TimeUntilMaxForce = 1.0f;

        public string InputBind = SRInput.Fire1;

        private float m_chargeTime = 0.0f;

        private bool m_shouldFire = false;

        private void ApplyBallForce( Rigidbody ball, float force ) {
            ball.AddRelativeForce( transform.up * force, ForceMode.VelocityChange );
        }

        private IEnumerator ChargeShot() {
            while ( true ) {
                m_chargeTime = Mathf.Min( m_chargeTime + Time.deltaTime, TimeUntilMaxForce );
                yield return null;
            }
        }

        private void FixedUpdate() {
            if ( !m_shouldFire ) {
                return;
            }
            float force = GetChargedForce();
            Rigidbody ball = MakeBall();
            ApplyBallForce( ball, force );
            Debug.LogFormat( "Spawned ball at {0} with force {1}.", ball.transform.position, force );
            m_shouldFire = false;
            m_chargeTime = 0.0f;
        } // Ball Launch

        private float GetChargedForce() { return Mathf.Lerp( MinForce, MaxForce, m_chargeTime / TimeUntilMaxForce ); }

        private Rigidbody MakeBall() {
            return Instantiate( BallPrefab, transform.position + transform.up, Quaternion.identity ) as Rigidbody;
        }

        private void Start() { } // Init

        private void StartCharging() {
            StopCharging();
            StartCoroutine( ChargeShot() );
        }

        private void StopCharging() { StopAllCoroutines(); }

        private void Update() {
            if ( Input.GetButtonDown( InputBind ) ) {
                StartCharging();
                m_shouldFire = false;
            }
            else if ( Input.GetButtonUp( InputBind ) ) {
                StopCharging();
                m_shouldFire = true;
            }
        } // Input Handling

    }

}
