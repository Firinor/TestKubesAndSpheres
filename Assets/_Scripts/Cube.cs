using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class Cube : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private ParticleSystem ps;

    private void Update()
    {
        AddForseToParticles();
    }

    private void AddForseToParticles()
    {
        var particles = new ParticleSystem.Particle[ps.particleCount];

        ps.GetParticles(particles);

        for (int i = 0; i < particles.GetUpperBound(0); i++)
        {
            float lifetime = particles[i].startLifetime - particles[i].remainingLifetime;
            float ForceToAdd = 
                lifetime * Vector3.Distance(target.position - transform.position, particles[i].position);

            particles[i].velocity = 
                (target.position - transform.position - particles[i].position).normalized * ForceToAdd;
        }

        ps.SetParticles(particles, particles.Length);
    }
}
