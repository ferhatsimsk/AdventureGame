using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcess1 : MonoBehaviour
{
    public PostProcessProfile postProcessProfile;
    private MotionBlur motionBlur;
    private Bloom bloom;
    void Start()
    {
        motionBlur = postProcessProfile.AddSettings<MotionBlur>();
        motionBlur.enabled.value = true; // Motion blur efektini etkinle�tirme
        motionBlur.shutterAngle.value = 180f; // Shutter a��s�n� 180 derece olarak ayarlama
        motionBlur.sampleCount.value = 8; // �rnekleme say�s�n� 8 olarak ayarlama

        bloom = postProcessProfile.AddSettings<Bloom>();
        bloom.enabled.value = true; // Bloom efektini etkinle�tirme
        bloom.intensity.value = 10f; // Bloom yo�unlu�unu ayarlama
        bloom.threshold.value = 1f; // Bloom e�i�ini ayarlama
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
