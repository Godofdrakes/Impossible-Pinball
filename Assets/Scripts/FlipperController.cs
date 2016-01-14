using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts {

    [ RequireComponent( typeof( HingeJoint ) ) ]
    public class FlipperController : MonoBehaviour {

        public int torqueValue = 500;

        public string InputBind = SRInput.Jump;

        public float activeAngle = 35;
        public float passiveAngle = -35;

        private HingeJoint hj;

        // Update is called once per frame
        void FixedUpdate() { Swing( Input.GetButton( InputBind ) ? activeAngle : passiveAngle, torqueValue ); }

        // Use this for initialization
        void Start() { hj = GetComponent<HingeJoint>(); }

        void Swing( float angle, float force ) {
            hj.spring = new JointSpring { spring = force, targetPosition = angle, damper = hj.spring.damper };
        }

    }

}
