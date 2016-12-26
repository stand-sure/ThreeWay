// //-----------------------------------------------------------------------
// // <copyright file="IPerson.cs" company="">
// //     Copyright (c) 2016 . All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------
//
namespace ThreeWay.Models
{
  using System.Collections.Generic;

  public interface IPerson
  {
    int Id { get; set; }
    string FirstName { get; set; }
    string LastName { get; set; }
    IEnumerable<IPerson> FamilyMembers { get; set; }
  }
}
