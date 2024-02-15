using Leopotam.Ecs;
using UnityEngine;

namespace ShooterRange.Shotgun
{
    public class ShotgunMovementHandler : IEcsRunSystem
    {
        private EcsFilter<ShotgunTag, WeaponHolderTransform, MovementScreenSpeed> _weaponHolders;

        public void Run()
        {
            Vector2 rayPoint = new Vector2(Input.mousePosition.x, 1);
            Ray ray = Camera.main.ScreenPointToRay(rayPoint);
            if(Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, 1 << LayerMask.NameToLayer("Table")))
            {
                foreach(int i in _weaponHolders)
                {
                    ref WeaponHolderTransform weaponHolderTransform = ref _weaponHolders.Get2(i);
                    float movementSpeed = _weaponHolders.Get3(i).value;
                    weaponHolderTransform.value.position = new Vector3(
                        Mathf.Lerp(weaponHolderTransform.value.position.x, raycastHit.point.x, Time.deltaTime * movementSpeed),
                        weaponHolderTransform.value.position.y,
                        weaponHolderTransform.value.position.z);
                }
            }

        }
    }
}