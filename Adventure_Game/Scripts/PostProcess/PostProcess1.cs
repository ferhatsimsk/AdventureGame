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
        motionBlur.enabled.value = true; // Motion blur efektini etkinleþtirme
        motionBlur.shutterAngle.value = 180f; // Shutter açýsýný 180 derece olarak ayarlama
        motionBlur.sampleCount.value = 8; // Örnekleme sayýsýný 8 olarak ayarlama

        bloom = postProcessProfile.AddSettings<Bloom>();
        bloom.enabled.value = true; // Bloom efektini etkinleþtirme
        bloom.intensity.value = 10f; // Bloom yoðunluðunu ayarlama
        bloom.threshold.value = 1f; // Bloom eþiðini ayarlama
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
