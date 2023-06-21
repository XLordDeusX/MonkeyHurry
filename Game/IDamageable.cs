using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public delegate void OnLifeChanged(int p_currentLife);
    public delegate void OnDestroyed(IDamageable p_destroyedObject);
    public interface IDamageable
    {
        int LifePoints { get; }
        bool IsDestroyed { get; set; }

        event OnLifeChanged OnLifeChanged;
        event OnDestroyed OnDestroyed;

        void GetDamage(int p_damage);
        void Destroy();
    }
}
