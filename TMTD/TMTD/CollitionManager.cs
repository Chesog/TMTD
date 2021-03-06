using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMTD
{
    class CollitionManager
    {
        private static CollitionManager instance;
        public static CollitionManager Getinstance() 
        {
            if (instance == null)
            {
                instance = new CollitionManager();
            }
            return instance;
        }

        private List<IColicionable> colicionables;
        private List<KeyValuePair<IColicionable, IColicionable>> collitionRegister;
        private CollitionManager() 
        {
            colicionables = new List<IColicionable>();
            collitionRegister = new List<KeyValuePair<IColicionable, IColicionable>>();
        }
        public void addToColitionManeger(IColicionable colitionable) 
        {
            colicionables.Add(colitionable);
        }
        public void removeFromColitionManager(IColicionable colicionable) 
        {
            if (colicionables.Contains(colicionable))
            {
                colicionables.Remove(colicionable);
            }
            
        }
        public void CheckColitions() 
        {
            for (int i = 0; i < colicionables.Count; i++)
            {
                for (int j = 0; j < colicionables.Count; j++)
                {
                    if (i != j)
                    {
                        if (colicionables[i] is CollisionableTile && colicionables[j] is CollisionableTile)
                        {
                            continue;
                        }
                        KeyValuePair<IColicionable, IColicionable> register = new KeyValuePair<IColicionable, IColicionable>(colicionables[i], colicionables[j]);
                        if (colicionables[i].GetBounds().Intersects(colicionables[j].GetBounds()))
                        {
                            colicionables[i].OnColitionStay(colicionables[j]);
                            if (!collitionRegister.Contains(register))
                            {
                                collitionRegister.Add(register);
                                colicionables[i].OnColitionEnter(colicionables[j]);
                            }  
                        }
                        else
                        {
                            if (collitionRegister.Contains(register))
                            {
                                collitionRegister.Remove(register);
                                colicionables[i].OnColitionExit(colicionables[j]);
                            }
                        }
                    }
                }
            }
        }
    }
}
