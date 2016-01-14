﻿using UnityEngine;

public class Bumper : MonoBehaviour
{
    public delegate void DOnHit(Bumper bumper);

    public enum Styles
    {
        Default = 0,
        Target = 1
    }

    [Range(0, 3)] public float BumperForce;

    public Styles BumperStyles;

    public DOnHit OnHit;

    public bool IsObjectEnabled
    {
        get { return gameObject.activeSelf; }
        set { gameObject.SetActive(value); }
    }

    private void Start()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        collision.rigidbody.AddForce(-1*collision.contacts[0].normal*BumperForce, ForceMode.Impulse);
        if (BumperStyles == Styles.Target)
        {
            IsObjectEnabled = false;
            if (OnHit != null)
            {
                OnHit(this);
            }
        }
    }
}