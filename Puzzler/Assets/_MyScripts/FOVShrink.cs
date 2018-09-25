using UnityEngine;
using UnityEngine.PostProcessing;

public class FOVShrink : MonoBehaviour {

	public float simulatedFOV;

	public float IPD;
	public float SCREEN_DISTANCE;

	public PostProcessingBehaviour postProcess;

	private VignetteModel vModel;
	private float         maxFOV;

	// Use this for initialization
	void Start () {
		vModel = postProcess.profile.vignette;
		maxFOV = Mathf.Rad2Deg * Mathf.Atan2(IPD / 2f, SCREEN_DISTANCE);
	}

	// Update is called once per frame
	void Update () {
		VignetteModel.Settings settings = vModel.settings;
		settings.intensity = 1f - Mathf.Clamp01(simulatedFOV / maxFOV);
		vModel.settings    = settings;
	}
}