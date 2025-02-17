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
        motionBlur.enabled.value = true; // Motion blur efektini etkinleştirme
        motionBlur.shutterAngle.value = 180f; // Shutter açısını 180 derece olarak ayarlama
        motionBlur.sampleCount.value = 8; // Örnekleme sayısını 8 olarak ayarlama

        bloom = postProcessProfile.AddSettings<Bloom>();
        bloom.enabled.value = true; // Bloom efektini etkinleştirme
        bloom.intensity.value = 10f; // Bloom yoğunluğunu ayarlama
        bloom.threshold.value = 1f; // Bloom eşiğini ayarlama
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
