using System.Collections.Generic;
using Obstacles;
using UnityEngine;


namespace Assets.Scripts.Environment {

    [ RequireComponent( typeof( IObstacle ) ) ]
    public class TogglesLightSwitch : MonoBehaviour {

        private LightSwitch[] m_lightSwitches = new LightSwitch[0];

        private IObstacle m_obstacle = null;

        [SerializeField] private bool m_invert = false;

        private void CheckLightSwitch( IObstacle sourceObject ) {
            foreach ( LightSwitch lightSwitch in m_lightSwitches ) {
                lightSwitch.IsEnabled = m_invert ? !sourceObject.IsObjectEnabled : sourceObject.IsObjectEnabled;
            }
        }

        private void OnDisable() { m_obstacle.OnHit -= CheckLightSwitch; }

        private void OnEnable() {
            m_lightSwitches = GetComponentsInChildren<LightSwitch>();
            m_obstacle = GetComponent<IObstacle>();
            m_obstacle.OnHit += CheckLightSwitch;
            CheckLightSwitch( m_obstacle );
        }

    }

}
