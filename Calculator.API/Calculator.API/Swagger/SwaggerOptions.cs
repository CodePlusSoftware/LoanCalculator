namespace Calculator.API.Swagger
{
  public class SwaggerOptions
  {
    /// <summary>
    ///   Gets or sets a value indicating whether enabled.
    /// </summary>
    public bool Enabled { get; set; }

    /// <summary>
    ///   Gets or sets the name.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    ///   Gets or sets the route prefix.
    /// </summary>
    public string RoutePrefix { get; set; }

    /// <summary>
    ///   Gets or sets the title.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    ///   Gets or sets the version.
    /// </summary>
    public string Version { get; set; }
  }
}