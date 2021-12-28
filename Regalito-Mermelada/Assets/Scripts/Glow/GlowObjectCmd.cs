using UnityEngine;
using System.Collections.Generic;

public class GlowObjectCmd : MonoBehaviour
{
	public Color GlowColor;
	public float LerpFactor = 10;

    public bool running = true;

	public Renderer[] Renderers
	{
		get;
		private set;
	}

	public Color CurrentColor
	{
		get { return _currentColor; }
	}

	private Color _currentColor;
	private Color _targetColor;

	void Start()
	{
		Renderers = GetComponentsInChildren<Renderer>();
		GlowController.RegisterObject(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            _targetColor = GlowColor;
            running = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _targetColor = Color.black;
            running = true;
        }
    }

	/// <summary>
	/// Update color, disable self if we reach our target color.
	/// </summary>
	private void Update()
	{
        if(running)
        {
		    _currentColor = Color.Lerp(_currentColor, _targetColor, Time.deltaTime * LerpFactor);

		    if (_currentColor.Equals(_targetColor))
		    {
			    running = false;
            }
        }
    }
}
