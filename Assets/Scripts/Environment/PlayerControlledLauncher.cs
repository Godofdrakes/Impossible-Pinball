using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Environment {

    [ RequireComponent( typeof( PinballLauncher ) ) ]
    public class PlayerControlledLauncher : MonoBehaviour {

        public string InputBind = SRInput.Fire1;

        private PinballLauncher m_pinballLauncher = null;

        private void Start() { m_pinballLauncher = GetComponent<PinballLauncher>(); }

        private void Update() { m_pinballLauncher.Charging = Input.GetButton( InputBind ); }

    }

}
