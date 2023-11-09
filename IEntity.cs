namespace PPM.Model
{
    public interface IEntity<T>
    {
        public void Add(T obj);
        public  List<T> ViewAll();
        public T ViewById(int ID);
        public void Delete(int ID);
    }
}