using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinbadColorinchins : MonoBehaviour
{
    [Range(0.0f, 10.0f)]
    public float LerpFactor = 10f;

    [Range(0.0f, 10.0f)]
    public float LerpTime = 4f;


    private Material[] _materials;

    private Color[] _nextColors;
    private Color[] _currentColors;
    private float[] _lerpT;

    private void Awake()
    {
        _materials = GetComponent<Renderer>().materials;

        _nextColors = new Color[_materials.Length];
        _currentColors = new Color[_materials.Length];
        _lerpT = new float[_materials.Length];

        for (int i = 0; i < _materials.Length; i++)
        {
            _currentColors[i] = _materials[i].color;
            _nextColors[i] = Random.ColorHSV();
            _lerpT[i] = 0.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {

        for (int i = 0; i < _materials.Length; i++)
        {
            _lerpT[i] += Time.deltaTime * LerpFactor;

            Color temp = Color.Lerp(_currentColors[i], _nextColors[i], _lerpT[i] / LerpTime);

            _materials[i].color = temp;

            if (_lerpT[i] >= LerpTime)
            {
                _currentColors[i] = _nextColors[i];
                _nextColors[i] = Random.ColorHSV();
                _lerpT[i] = 0.0f;
            }
        }
    }
}
