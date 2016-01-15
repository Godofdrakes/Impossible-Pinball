using System.Collections.Generic;
using Assets.Scripts.Extention_Methods;
using Obstacles;
using UnityEngine;


namespace Assets.Scripts.Audio_Controllers {

    [ RequireComponent( typeof( IObstacle ), typeof( AudioSource ) ) ]
    public class HitSoundEmitter : MonoBehaviour {

        public AudioClip[] HitAudioClips = new AudioClip[0];

        private IObstacle m_obstacle = null;

        private AudioSource m_audioSource = null;

        private void ObstacleOnOnHit( IObstacle bumper ) {
            AudioClip randomClip = HitAudioClips.GetRandom();
            if ( randomClip != null ) {
                m_audioSource.clip = randomClip;
                m_audioSource.Play();
            }
            else {
                Debug.LogWarningFormat( "#{0}# No available audio sources.", GetType().Name );
            }
        }

        private void Start() {
            m_obstacle = GetComponent<IObstacle>();
            m_audioSource = GetComponent<AudioSource>();
            m_obstacle.OnHit += ObstacleOnOnHit;
        }

    }

}
