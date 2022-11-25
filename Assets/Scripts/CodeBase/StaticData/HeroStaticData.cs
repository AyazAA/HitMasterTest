using UnityEngine;

namespace CodeBase.StaticData
{
    [CreateAssetMenu(fileName = "HeroData", menuName = "StaticData/Hero")]
    public class HeroStaticData : ScriptableObject
    {
        [Range(2,15)]
        public float Speed = 3.5f;

        [Range(1,10)]
        public float BulletSpeed = 3;
        
        [Range(0,1)]
        public float Damage = 0.35f;

        public AudioClip ShootSound;
    }
}