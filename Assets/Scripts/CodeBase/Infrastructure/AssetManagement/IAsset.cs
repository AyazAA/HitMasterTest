using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public interface IAsset : IService
    {
        public GameObject Instantiate(string path);
        public GameObject Instantiate(string path, Vector3 at);
    }
}