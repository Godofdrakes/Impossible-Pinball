using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Environment {

    [RequireComponent( typeof( Collider ) )]
    public class BallRemover : MonoBehaviour {
        public void OnTriggerEnter( Collider other ) {
            if ( other.tag == SRTags.Ball ) {
                Destroy( other.gameObject );
            }
        }
    }

}
