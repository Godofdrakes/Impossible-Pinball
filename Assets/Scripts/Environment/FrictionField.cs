using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Environment {

    /// <summary>
    /// While other <see cref="Rigidbody"/>s are within this field, their drag will be set to this object's drag.
    /// </summary>
    [ RequireComponent( typeof( Collider ), typeof( Rigidbody ) ) ]
    public class FrictionField : MonoBehaviour {

        private Rigidbody m_rigidbody = null;

        private Dictionary<Rigidbody, float> m_frictionDictionary = new Dictionary<Rigidbody, float>();

        private void OnTriggerEnter( Collider other ) {
            if ( other.tag != SRTags.Ball ) { return; }
            m_frictionDictionary[other.attachedRigidbody] = other.attachedRigidbody.drag;
            other.attachedRigidbody.drag = m_rigidbody.drag;
        }

        private void OnTriggerExit( Collider other ) {
            if ( !m_frictionDictionary.ContainsKey( other.attachedRigidbody ) ) { return; }
            other.attachedRigidbody.drag = m_frictionDictionary[other.attachedRigidbody];
            m_frictionDictionary.Remove( other.attachedRigidbody );
        }

        private void Start() { m_rigidbody = GetComponent<Rigidbody>(); }

    }

}
