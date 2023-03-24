namespace GraphLibrary;

public abstract class BasicVertexProperty
{
  // fields
  public uint Id;
  public string Name = "Unknown Name";
}

public class Vertex<T> where T : BasicVertexProperty, new()
{
  // fields
  private T _property;

  // constructor
  public Vertex(uint id, string name)
  {
    _property = new T();
    _property.Id = id;
    _property.Name = name;
  }

  // getters & setters
  public T Property
  {
    get { return _property; }
    set { _property = value; }
  }

  // finalizer
  ~Vertex() { }

  // methods
}