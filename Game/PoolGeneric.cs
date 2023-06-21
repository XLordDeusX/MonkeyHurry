using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class PoolGeneric<T>
    {
        private List<T> m_inUseObjects;
        private List<T> m_poolObjects;

        public PoolGeneric()
        {
            m_inUseObjects = new List<T>();
            m_poolObjects = new List<T>();
        }

        public T GetObjectsFromPool()
        {
            if (m_poolObjects.Count > 0)
            {
                var l_availableObj = m_poolObjects[0];
                m_poolObjects.Remove(l_availableObj);
                m_inUseObjects.Add(l_availableObj);
                return l_availableObj;
            }
            return default;
        }
    }
}
