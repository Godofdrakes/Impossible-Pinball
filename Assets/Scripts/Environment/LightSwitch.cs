using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Environment {

    [ RequireComponent( typeof( MeshRenderer ) ) ]
    public class LightSwitch : MonoBehaviour {

        public Color EnabledColor = Color.black, DisabledColor = Color.white;

        private MeshRenderer m_meshRenderer = null;

        private bool m_isEnabled = false;

        [ SerializeField ] private bool m_initialState = false;

        public bool IsEnabled {
            get { return m_isEnabled; }
            set {
                m_isEnabled = value;
                SetColor( m_isEnabled ? EnabledColor : DisabledColor );
            }
        }

        private void OnEnable() {
            m_meshRenderer = GetComponent<MeshRenderer>();
            IsEnabled = m_initialState;
        }

        private void SetColor( Color c )
        {
            Debug.Log(m_isEnabled);
            m_meshRenderer.material.EnableKeyword("_EMISSION");
            m_meshRenderer.material.SetColor( "_EmissionColor", c );
        }

    }

}
