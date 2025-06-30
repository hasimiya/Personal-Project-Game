using System.Collections.Generic;
using UnityEngine;
using static ParticleSystemType;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] private ParticleSystemType particleSystemType;
    private Dictionary<ParticleSystemTypeEnum, ParticleSystem> particleMap;

    private void Awake()
    {
        particleMap = new Dictionary<ParticleSystemTypeEnum, ParticleSystem>
        {
            { ParticleSystemTypeEnum.Destroyed, particleSystemType.destroyedParticleSystem}
        };
    }
    public void SpawnParticle(ParticleSystemTypeEnum type, Vector3 position)
    {
        if (particleMap.TryGetValue(type, out ParticleSystem partial) && partial != null)
        {
            ParticleSystem particleSystem = Instantiate(partial, position, Quaternion.identity);
            particleSystem.Play();
            Destroy(particleSystem.gameObject, particleSystem.main.duration + particleSystem.main.startLifetime.constant);
        }
        else
        {
            Debug.LogWarning($"Particle system of type {type} not found or is null.");
        }
    }
}
