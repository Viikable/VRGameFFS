using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (AudioSource))]
public class AudioPeer : MonoBehaviour {
    AudioSource _audioSource;
    public static float[] _samples = new float[512];
    float[] _freqBand = new float[8];
    float[] _bandBuffer = new float[8];
    float[] _bufferDecrease = new float[8];

    float[] _freqBandHighest = new float[8];
    public static float[] _audioBand = new float[8];
    public static float[] _audioBandBuffer = new float[8];

    public static float _Amplitude, _AmplitudeBuffer;
    float _AmplitudeHighest;

    // Use this for initialization
    void Start () {
        _audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
        GetAmplitude();
	}

    void GetAmplitude()
    {
        float _CurrentAmplitude = 0;
        float _CurrentAmplitudeBuffer = 0;
        for (int i = 0; i < 8; i++)
        {
            _CurrentAmplitude += _audioBand[i];
            _CurrentAmplitudeBuffer += _audioBandBuffer[i];
        }
        if (_CurrentAmplitude > _AmplitudeHighest)
        {
            _AmplitudeHighest = _CurrentAmplitude;
        }
        _Amplitude = _CurrentAmplitude / _AmplitudeHighest;
        _AmplitudeBuffer = _CurrentAmplitudeBuffer / _AmplitudeHighest;
    }

    void CreateAudioBands()
    {
        for (int i = 0; i < 8; i++)
        {
             if (_freqBand[i] > _freqBandHighest [i])
            {
                _freqBandHighest[i] = _freqBand[i];
            }
            _audioBand[i] = (_freqBand[i] / _freqBandHighest[i]);
            _audioBandBuffer[i] = (_bandBuffer[i] / _freqBandHighest[i]);
        }
    }



    void GetSpectrumAudioSource()
    {
        _audioSource.GetSpectrumData(_samples, 0, FFTWindow.Blackman);
    }
    void BandBuffer()
    {
        for (int g = 0; g < 8; g++)
        {
            if (_freqBand[g] > _bandBuffer[g])
            {
                _bandBuffer[g] = _freqBand[g];
                _bufferDecrease[g] = 0.005f;
            }

            if (_freqBand [g] < _bandBuffer[g])
            {
                _bandBuffer [g] -= _bufferDecrease[g];
                _bufferDecrease[g] *= 1.2f;
            }
        }
    }

    void MakeFrequencyBands()          //aim to divide the frequency spectrum to 8 parts
    {
        /* 22050 / 512 = 43hertz per sample
        *20 - 60 hertz
        60 - 250 Hz
        250 - 500 hertz
        500 - 2000 Hz
        2000 - 40000 Hz
        4000 - 6000 Hz
        6000 - 20000Hz
        * 0-2  = 86Hz  (2 times 43Hz)
        * 1-4  = 172 Hz (4 times 43Hz) adding this and the previous together we get a range of 87-258Hz
        * 2-8  = 344 Hz (8 times 43Hz) combined previous: 259-602 Hz
        * 3-16 = 688 Hz, combined: 603-1290 Hz
        * 4-32 = 1376 Hz, 1291-2666 Hz
        * 5-64 = 2752 Hz, 2667-5418 Hz
        * 6-128 = 5504 Hz, 5419-10922 Hz
        * 7-256 = 11008 Hz, 10923-21930 Hz             so these are the 8 ranges we can use
        * this makes 510 samples, we could add 2 in the code to make around 22k Hz
        * */

        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)            //this adds the remaining 2 samples in the last part so we get 512 samples
            {
                sampleCount += 2;   
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += _samples[count] * (count + 1);
                count++;
            }
            average /= count;

            _freqBand[i] = average * 10;
        }

    }
}
