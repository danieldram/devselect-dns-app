using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test_net_app.Models;


public class CategoryModel
{
	[Key]
	public int Id { get; set; }

	[Required]
	public string Name { get; set; } = "";

	[DisplayName("Display Name")]
	public int DisplayName { get; set; }

	public DateTime CreatedDateTime { get; set; } = DateTime.Now;
}

