using System;
using Microsoft.EntityFrameworkCore;
using test_net_app.Models;
namespace test_net_app.Data;


public class AppDBContext :DbContext
{
	public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
	{
	}
	public DbSet<test_net_app.Models.DNSZones>? DNSZones { get; set; }
	public DbSet<test_net_app.Models.DNSRecords>? DNSRecords { get; set; }
}

