using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour
{
    public int _band;
    public float _startScale, _scaleMultiplier;
    public bool _useBuffer;
    private AudioPeer ääniKaveri;
    Material _material;

    // Use this for initialization
    void Start()
    {
        _material = GetComponent<MeshRenderer>().materials[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (_useBuffer && ääniKaveri.AudioBand64[_band] > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, (ääniKaveri.AudioBandBuffer64[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
            Color _color = new Color(ääniKaveri.AudioBandBuffer64[_band], ääniKaveri.AudioBandBuffer64[_band], ääniKaveri.AudioBandBuffer64[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
        if(!_useBuffer && ääniKaveri.AudioBand64[_band] > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x, (ääniKaveri.AudioBand64[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
            Color _color = new Color(ääniKaveri.AudioBand64[_band], ääniKaveri.AudioBand64[_band], ääniKaveri.AudioBand64[_band]);
            _material.SetColor("_EmissionColor", _color);
        }
    }
}
