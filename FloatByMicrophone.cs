using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class MicGravity : MonoBehaviour
{
    public float liftPower = 500f;
    private Rigidbody rb;
    private AudioSource micSource;
    private float[] spectrum = new float[64];

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        micSource = GetComponent<AudioSource>();

        // 1. Find the default microphone and start recording
        if (Microphone.devices.Length > 0)
        {
            micSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
            micSource.loop = true;

            // 2. Wait for the mic to turn on, then play the audio data internally
            while (!(Microphone.GetPosition(null) > 0)) { }
            micSource.Play();
        }
    }

    void Update()
    {
        // 3. Measure the volume (spectrum data)
        micSource.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);
        float volume = spectrum[0];

        // 4. If volume is loud enough, apply upward force
        if (volume > 0.01f)
        {
            rb.AddForce(Vector3.up * volume * liftPower, ForceMode.Acceleration);
        }
    }
}