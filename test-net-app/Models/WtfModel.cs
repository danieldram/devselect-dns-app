using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test_net_app.Models;


public class WtfModel
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string FuckingBullshit { get; set; } = "";

}

