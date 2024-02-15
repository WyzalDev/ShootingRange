using Leopotam.Ecs;
using UnityEngine;


namespace ShooterRange.Shotgun
{
    public class ShotgunLookOnMouseLocker : IEcsRunSystem, IEcsInitSystem
    {
        private EcsFilter<ShotgunTag, ShotgunTransform, RotationSpeed> _shotguns;

        private float _rotationSpeed;

        public void Init()
        {
            foreach(int i in _shotguns)
            {
                RotationSpeed rotationSpeed = _shotguns.Get3(i);
                _rotationSpeed = rotationSpeed.value;
            }
        }

        public void Run()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue,
                LayerMask.GetMask("Environment")))
            {
                foreach(int i in _shotguns)
                {
                    ref ShotgunTransform shotgunTransform = ref _shotguns.Get2(i);
                    shotgunTransform.value.localRotation = Quaternion.Slerp(
                            shotgunTransform.value.localRotation,
                            Quaternion.LookRotation(raycastHit.point - shotgunTransform.value.position),
                            _rotationSpeed * Time.deltaTime);
                }
            }

        }
    }
}