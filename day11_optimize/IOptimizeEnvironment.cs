namespace week2 {
    public interface IOptimizeEnvironment: IOptimizeEnvironment{
        Symbols Symbols { get; }
        void Add(int nest, int index, object value);
        object Get(int nest, int index);
        void PutNew(string name, object value);
        IOptimizeEnvironment Where(string name);
    }

}