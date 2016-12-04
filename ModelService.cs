using System;
using System.Collections.Generic;

namespace Environment.Injector {
        
    public class ModelService : IDisposable
    {
        Dictionary<string, Type> _Map = new Dictionary<string, Type>();

        static ModelService _Instance = new ModelService(); 
        
        public static ModelService Instance {
            get {
                return _Instance;
            }
        }

        public ModelService Init(){
            _Map.Clear();
            return this;
        }

        public ModelService Map<T, W>() 
            where W:T {
            string genericType = typeof(T).Name;
            Type concreteType = typeof(W);
            if(!_Map.ContainsKey(genericType))
                _Map.Add(genericType, concreteType);
            else
                _Map[genericType] = concreteType;

            return this;
        } 

        public T GetNew<T>(params object[] args) {
            string genericType = typeof(T).Name;
            if(!_Map.ContainsKey(genericType)){
                throw new NotSupportedException();
            }
            
            if(args.Length>0)
                return (T)Activator.CreateInstance(_Map[genericType], args);
            else
                return (T)Activator.CreateInstance(_Map[genericType]);

        }

        public void Dispose(){
            this._Map.Clear();
            _Instance = null;

        }

    }
}
