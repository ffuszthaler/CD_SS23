namespace GraphLibrary;

public abstract class BasicEdgeProperty
{
  // fields
  public uint Id;
  public uint SourceId;
  public uint TargetId;
}

public class Edge<T> where T : BasicEdgeProperty, new()
{
  // fields
  private T _property;

  // constructor
  public Edge(uint id, uint source, uint target)
  {
    _property = new T();
    _property.Id = id;
    _property.SourceId = source;
    _property.TargetId = target;
  }

  // getters & setters
  public T Property
  {
    get { return _property; }
    set { _property = value; }
  }

  // finalizer
  ~Edge() { }

  // methods
}