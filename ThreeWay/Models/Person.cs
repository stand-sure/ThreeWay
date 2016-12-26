// //-----------------------------------------------------------------------
// // <copyright file="Person.cs" company="">
// //     Copyright (c) 2016 . All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------
//
namespace ThreeWay.Models
{
  using System.Collections.Generic;

  public class Person
  {
    /// <summary>
    /// Gets or sets the first name.
    /// </summary>
    /// <value>The first name.</value>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name.
    /// </summary>
    /// <value>The last name.</value>
    public string LastName { get; set; }

    public override string ToString()
    {
      return string.Format("{0} {1}", FirstName, LastName);
    }
  }
}
