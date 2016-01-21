using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Environment {

    public class BumperGroup : MonoBehaviour {

        private BallBumper[] m_bumpers = new BallBumper[0];

        [SerializeField] private int m_pointValue = 0;

        private void OnEnable() { m_bumpers = GetComponentsInChildren<BallBumper>(); }

        private Coroutine _coroutine = null;

        private int ActiveChildren
        {
            get
            {
                var n = 0;
                foreach (var child in m_bumpers)
                {
                    if (child.IsObjectEnabled)
                    {
                        ++n;
                    }
                }
                return n;
            }
        }

        public void Start()
        {
            Debug.Log("Current m_bumpers length: " + m_bumpers.Length);
            Debug.Log("Current Active Children: "  + ActiveChildren);
        }

        public void Update()
        {
            if (_coroutine == null)
            {
                if (ActiveChildren == 0)
                {
                     _coroutine = StartCoroutine(EnableChildren());
                }
            }
        }

        private IEnumerator EnableChildren()
        {

            yield return new WaitForSeconds(1.0f);
            foreach (var ballBumper in m_bumpers)
            {
                ballBumper.Reset();
                
            }
            ScoreDisplay.AddScore(m_pointValue);
            _coroutine = null;
        } 
    }

}
