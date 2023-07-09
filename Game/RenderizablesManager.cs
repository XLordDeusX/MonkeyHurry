using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class RenderizablesManager
    {
        private static RenderizablesManager instance;

        private List<IRenderizable> renderizables = new List<IRenderizable>();

        public List<IRenderizable> GetObjets()
        {
            List<IRenderizable> objects = new List<IRenderizable>(renderizables);
            return objects;
        }

        public static RenderizablesManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RenderizablesManager();
                }
                return instance;
            }
        }

        public void AddObjet(IRenderizable p_newObject)
        {
            renderizables.Add(p_newObject);
        }
    }
}
