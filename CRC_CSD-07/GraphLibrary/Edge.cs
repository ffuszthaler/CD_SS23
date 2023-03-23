namespace GraphLibrary;

public struct EdgeProperty
{
  // fields
  public uint Id;
  public uint SourceId;
  public uint TargetId;
}

public class Edge
{
  // fields
  private EdgeProperty _property;

  // constructor
  public Edge(uint id, uint source, uint target)
  {
    _property = new EdgeProperty();
    _property.Id = id;
    _property.SourceId = source;
    _property.TargetId = target;
  }

  // getters & setters
  public EdgeProperty Property
  {
    get { return _property; }
    set { _property = value; }
  }

  // finalizer
  ~Edge() { }

  // methods
}