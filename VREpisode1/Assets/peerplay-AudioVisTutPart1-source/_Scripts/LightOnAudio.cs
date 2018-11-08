using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOnAudio : MonoBehaviour {
    public int _band;
    public float _minIntensity, _maxIntensity;
    private AudioPeer _audioPeer;
    Light _light;
    
	// Use this for initialization
	void Start () {
        _light = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        _light.intensity = (_audioPeer._audioBandBuffer[_band] * (_maxIntensity - _minIntensity)) + _minIntensity;
	}
}
