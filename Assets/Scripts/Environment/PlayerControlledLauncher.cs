﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Assets.Scripts.Environment {

    [ RequireComponent( typeof( PinballLauncher ) ) ]
    public class PlayerControlledLauncher : MonoBehaviour {

        public string InputBind = SRInput.Fire1;

        [ SerializeField ]
        Rigidbody[] m_initialBalls = new Rigidbody[0];

        private PinballLauncher m_pinballLauncher = null;

        public static PlayerControlledLauncher MainLauncher {
            get {
                return
                    FindObjectsOfType<PlayerControlledLauncher>()
                        .First( launcher => launcher.tag == SRTags.Main_Ball_Launcher );
            }
        }

        public PinballLauncher PinballLauncher { get { return m_pinballLauncher; } }

        private void Start() {
            m_pinballLauncher = GetComponent<PinballLauncher>();
            foreach ( Rigidbody ball in m_initialBalls ) {
                m_pinballLauncher.AddBallToQueue( Instantiate( ball ) );
            }
            m_initialBalls = new Rigidbody[0];
        }

        private void Update() { m_pinballLauncher.Charging = Input.GetButton( InputBind ); }

    }

}
