using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Environment {

    public class BumperGroup : MonoBehaviour {

        private Bumper[] m_bumpers = new Bumper[0];

        private void OnEnable() { m_bumpers = GetComponentsInChildren<Bumper>(); }

    }

}
