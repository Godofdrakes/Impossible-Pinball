using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Environment {

    [RequireComponent( typeof(SphereCollider) )]
    public class FlowField : MonoBehaviour {

        private SphereCollider m_sphereCollider;

        public enum FlowMode {

            Pull = -1,
            Disabled = 0,
            Push = 1,

        }

        public AnimationCurve ForceMultiplier = AnimationCurve.Linear( 0.0f, 0.0f, 1.0f, 1.0f );

        [ Range( 0.1f, 2.0f ) ] public float ForceStrength = 0.50f;

        public FlowMode Mode = FlowMode.Pull;

        private void OnTriggerStay( Collider other ) {
            if ( other.tag != SRTags.Ball ) { return; }
            Vector3 direction = other.transform.position - transform.position;
            Debug.DrawLine( transform.position, transform.position + direction );
            float force = ForceStrength * CalculateForceMultiplier( direction.magnitude ) * (int)Mode;
            other.attachedRigidbody.AddForce( direction * force );
        }

        private void Start() { m_sphereCollider = GetComponent<SphereCollider>(); }

        private float CalculateForceMultiplier( float distance ) {
            return distance > m_sphereCollider.radius ? 0.0f : ForceMultiplier.Evaluate( distance / m_sphereCollider.radius );
        }

    }

}
