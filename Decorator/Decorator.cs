using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace marvertus_zadaca_3.Decorator
{
    public abstract class Decorator:DComponent
    {
       
            protected DComponent _component;

            public Decorator(DComponent component)
            {
                this._component = component;
            }

            public void SetComponent(DComponent component)
            {
                this._component = component;
            }

            // The Decorator delegates all work to the wrapped component.
            public override string Ispis(string text)
            {
                if (this._component != null)
                {
                    return this._component.Ispis(text);
                    

                }
                else
                {
                    return string.Empty;
                }
            }
        }
    
}
