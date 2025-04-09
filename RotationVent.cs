using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationVent : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 10f; // �������� �������� (������� � �������)
    [SerializeField] private float minPauseTime = 1f;    // ����������� ����� �����
    [SerializeField] private float maxPauseTime = 3f;    // ������������ ����� �����
    [SerializeField] private float minRotateTime = 3f;   // ����������� ����� ��������
    [SerializeField] private float maxRotateTime = 7f;   // ������������ ����� ��������

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

    // ��������� �������� 
    public void StopRotation()
    {
        if (rotationCoroutine != null)
        {
            StopCoroutine(rotationCoroutine);
        }
    }
}
