using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(NoiseFlowField))]
public class AudioFlowField : MonoBehaviour {
    NoiseFlowField _noiseFlowField;
    public AudioPeer _audioPeer;
    [Header("Speed")]
    public bool _useSpeed;
    public Vector2 _moveSpeedMinMax, _rotateSpeedMinMax;
    [Header("Scale")]
    public bool _useScale;
    public Vector2 _scaleMinMax;
    [Header("Material")]
    public Material _material;
    private Material[] _audioMaterial;
    public bool _useColor1;
    public string _colorName1;
    public Gradient _gradient1;
    private Color[] _color1;
    [Range(0f, 1f)]
    public float _colorThreshold1;
    public float _colortMultiplier1;
    public bool _useColor2;
    public string _colorName2;
    public Gradient _gradient2;
    private Color[] _color2;
    [Range(0f, 1f)]
    public float _colorThreshold2;
    public float _colortMultiplier2;

    // Use this for initialization
    void Start () {
        _noiseFlowField = GetComponent<NoiseFlowField>();
        _audioMaterial = new Material[64];
        _color1 = new Color[64];
        _color2 = new Color[64];
        for (int i = 0; i < 64; i++)
        {
            _color1[i] = _gradient1.Evaluate((1f / 8f) * i);
            _color2[i] = _gradient2.Evaluate((1f / 8f) * i);
            _audioMaterial[i] = new Material(_material);
        }
        int countBand = 0;

        for (int i = 0; i < _noiseFlowField._amountOfParticles; i++)
        {
            int band = countBand % 64;
            _noiseFlowField._particleMeshRenderer[i].material = _audioMaterial[band];
            _noiseFlowField._particles[i]._audioBand = band;
            countBand++;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (_useSpeed)
        {
            _noiseFlowField._particleMoveSpeed = Mathf.Lerp(_moveSpeedMinMax.x, _moveSpeedMinMax.y, _audioPeer._AmplitudeBuffer);
            _noiseFlowField._particleRotateSpeed = Mathf.Lerp(_rotateSpeedMinMax.x, _rotateSpeedMinMax.y, _audioPeer._AmplitudeBuffer);

            for (int i = 0; i < _noiseFlowField._amountOfParticles; i++)
            {
                if (_useScale)
                {
                    float scale = Mathf.Lerp(_scaleMinMax.x, _scaleMinMax.y, _audioPeer._audioBandBuffer64[_noiseFlowField._particles[i]._audioBand]);
                    _noiseFlowField._particles[i].transform.localScale = new Vector3(scale, scale, scale);
                }
            }
        }
        for (int i = 0; i < 64; i++)
        {
            if (_useColor1)
            {
                if (_audioPeer._audioBandBuffer64[i] > _colorThreshold1)
                {
                    _audioMaterial[i].SetColor(_colorName1, _color1[i] * _audioPeer._audioBandBuffer64[i] * _colortMultiplier1);
                }
                else
                {
                    _audioMaterial[i].SetColor(_colorName1, _color1[i] * 0f);
                }
            }
            if (_useColor2)
            {
                if (_audioPeer._audioBandBuffer64[i] > _colorThreshold2)
                {
                    _audioMaterial[i].SetColor(_colorName2, _color2[i] * _audioPeer._audioBand64[i] * _colortMultiplier2);
                }
                else
                {
                    _audioMaterial[i].SetColor(_colorName2, _color2[i] * 0f);
                }
            }
        }
	}
}
