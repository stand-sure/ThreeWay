// //-----------------------------------------------------------------------
// // <copyright file="startup.cs" company="">
// //     Copyright (c) 2016 . All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------
//
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;

[assembly:Microsoft.Owin.OwinStartup(typeof(ThreeWay.Startup))]
namespace ThreeWay
{
  public class Startup
  {
    public IConfiguration Configuration { get; set; }

    public Startup(IHostingEnvironment env)
    {
      // Setup configuration sources.
      //Configuration = new Configuration()
      //    .AddJsonFile("config.json")
      //    .AddEnvironmentVariables();

      var builder = new ConfigurationBuilder();
      builder.AddJsonFile(string.Empty);
      builder.AddEnvironmentVariables();
      Console.WriteLine("startup");
    }

    public void Configure(IApplicationBuilder app)
    {
      
    }
  }
}
