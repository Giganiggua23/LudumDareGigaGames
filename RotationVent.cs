using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationVent : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f; // Скорость вращения (градусы в секунду)
    [SerializeField] private float minPauseTime = 1f;    // Минимальное время паузы
    [SerializeField] private float maxPauseTime = 3f;    // Максимальное время паузы
    [SerializeField] private float minRotateTime = 3f;   // Минимальное время вращения
    [SerializeField] private float maxRotateTime = 7f;   // Максимальное время вращения

    private Coroutine rotationCoroutine;

    private void Start()
    {
        rotationCoroutine = StartCoroutine(RotateWithRandomPauses());
    }

    private IEnumerator RotateWithRandomPauses()
    {
        while (true) 
        {
           
            float rotateTime = Random.Range(minRotateTime, maxRotateTime);
            float elapsedTime = 0f;

            while (elapsedTime < rotateTime)
            {
                transform.Rotate(Vector3.forward * (rotationSpeed * Time.deltaTime));
                elapsedTime += Time.deltaTime;
                yield return null;
            }

           
            float pauseTime = Random.Range(minPauseTime, maxPauseTime);
            yield return new WaitForSeconds(pauseTime);
        }
    }

    // Остановка вращения 
    public void StopRotation()
    {
        if (rotationCoroutine != null)
        {
            StopCoroutine(rotationCoroutine);
        }
    }
}
