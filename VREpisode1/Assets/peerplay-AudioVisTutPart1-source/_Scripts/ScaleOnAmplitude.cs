using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnAmplitude : MonoBehaviour {
    public float _startScale, _maxScale;
    public bool _useBuffer;
    Material _material;
    public float _red, _green, _blue;
    private AudioPeer _audioPeer;

    // Use this for initialization
    void Start () {
        _material = GetComponent < MeshRenderer>().materials[0];
	}
	
	// Update is called once per frame
	void Update () {
        if (_useBuffer && _audioPeer._Amplitude > 0)
        {
            transform.localScale = new Vector3((_audioPeer._Amplitude * _maxScale) + _startScale, (_audioPeer._Amplitude * _maxScale) + _startScale, (_audioPeer._Amplitude * _maxScale) + _startScale);
            Color _color = new Color(_red * _audioPeer._Amplitude, _green * _audioPeer._Amplitude, _blue * _audioPeer._Amplitude);
            _material.SetColor("_EmissionColor", _color);
        }
        if (!_useBuffer && _audioPeer._AmplitudeBuffer > 0)
        {
            transform.localScale = new Vector3((_audioPeer._AmplitudeBuffer * _maxScale) + _startScale, (_audioPeer._AmplitudeBuffer * _maxScale) + _startScale, (_audioPeer._AmplitudeBuffer * _maxScale) + _startScale);
            Color _color = new Color(_red * _audioPeer._AmplitudeBuffer, _green * _audioPeer._AmplitudeBuffer, _blue * _audioPeer._AmplitudeBuffer);
            _material.SetColor("_EmissionColor", _color);
        }

    }
}
