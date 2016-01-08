using System;
using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts {

    [RequireComponent( typeof( Rigidbody ) )]
    public class SpringLauncher : MonoBehaviour {

        [Range( 0.01f, float.PositiveInfinity )]
        public float MinStrength = 1.0f;

        [Range( 0.01f, float.PositiveInfinity )]
        public float MaxStrength = 5.0f;

        [Range( 0.01f, Single.PositiveInfinity )]
        public float TimeUntilMaxStrength = 2.0f;

        private Rigidbody m_rigidbody = null;

        public string InputBinding = SRInput.Fire1;

        private bool m_charging = false;

        private float m_timeSpentCharging = 0.0f;

        private void Start( ) { m_rigidbody = GetComponent<Rigidbody>(); }

        private void FixedUpdate( ) {
            if( m_charging ) {
                m_timeSpentCharging = Mathf.Min( m_timeSpentCharging + Time.fixedDeltaTime, TimeUntilMaxStrength );
            }
            else {
                m_rigidbody.AddForce( 0.0f,
                                      0.0f,
                                      Mathf.Lerp( MinStrength, MaxStrength, m_timeSpentCharging / TimeUntilMaxStrength ) );
            }
        }

        private void Update( ) {
            m_charging = !m_charging ? Input.GetButtonDown( InputBinding ) : Input.GetButtonUp( InputBinding );
        }

    }

}
