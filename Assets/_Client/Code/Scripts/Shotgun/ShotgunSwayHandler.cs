using Leopotam.Ecs;
using UnityEngine;

namespace ShooterRange.Shotgun
{
    public class ShotgunSwayHandler : IEcsRunSystem
    {
        private EcsFilter<ShotgunTag, WeaponSway, WeaponHolderTransform> _shotguns;

        public void Run()
        {
            foreach(int i in _shotguns)
            {
                ref WeaponSway weaponSway = ref _shotguns.Get2(i);
                float mouseX = Input.GetAxisRaw("Mouse X") * weaponSway.multiplier;
                float mouseY = Input.GetAxisRaw("Mouse Y") * weaponSway.multiplier;

                Quaternion rotationX = Quaternion.AngleAxis(-mouseY, Vector3.right);
                Quaternion rotationY = Quaternion.AngleAxis(mouseX, Vector3.up);

                Quaternion targetRotation = rotationX * rotationY;

                ref WeaponHolderTransform weaponHolderTransform = ref _shotguns.Get3(i);
                weaponHolderTransform.value.localRotation = Quaternion.Slerp(
                    weaponHolderTransform.value.localRotation, targetRotation, weaponSway.smooth * Time.deltaTime);
            }
        }
    }
}