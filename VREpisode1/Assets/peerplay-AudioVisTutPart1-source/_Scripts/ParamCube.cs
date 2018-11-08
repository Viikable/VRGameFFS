using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;
    Material _material;
    AudioPeer _audioPeer;

    // Use this for initialization
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer && _audioPeer._audioBand64[_band] > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, (_audioPeer._audioBandBuffer64[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
            Color _color = new Color(_audioPeer._audioBandBuffer64[_band], _audioPeer._audioBandBuffer64[_band], _audioPeer._audioBandBuffer64[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
        if (!_useBuffer && _audioPeer._audioBand64[_band] > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, (_audioPeer._audioBand64[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
            Color _color = new Color(_audioPeer._audioBand64[_band], _audioPeer._audioBand64[_band], _audioPeer._audioBand64[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
    }
}
