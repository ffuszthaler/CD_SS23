namespace GraphLibrary;

public struct VertexProperty
{
  // fields
  public uint Id;
  public string Name;
}

public class Vertex
{
  // fields
  private VertexProperty _property;

  // constructor
  public Vertex(uint id, string name)
  {
    _property = new VertexProperty();
    _property.Id = id;
    _property.Name = name;
  }

  // getters & setters
  public VertexProperty Property
  {
    get { return _property; }
    set { _property = value; }
  }

  // finalizer
  ~Vertex() { }

  // methods
}