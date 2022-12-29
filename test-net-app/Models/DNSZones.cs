using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test_net_app.Models;


public class DNSZones
{
    [Key]
    public int Id { get; set; }

    [Required]
    [RegularExpression(@"[0-9aA-zZ]+\.[0-9aA-zZ]+", ErrorMessage = "Invalid format for domain")]
    public string Doamin { get; set; } = "";

    [Required]
    [RegularExpression(@"[0-9aA-zZ]+\.[0-9aA-zZ]+\.[0-9aA-zZ]+\.[0-9aA-zZ]", ErrorMessage = "Invalid format for IP address")]
    [DisplayName("IP(4)")]
    public string IP { get; set; } = "";

    [Required]
    [RegularExpression(@"[0-9aA-zZ]+@[0-9aA-zZ]+\.[0-9aA-zZ]+", ErrorMessage = "Invalid format for email")]
    public string Email { get; set; } = "";

    [DisplayName("TTL")]
    public int TTL { get; set; } = 60;

    [DisplayName("Refresh")]
    public int Refresh { get; set; } = 60;

    [DisplayName("Retry")]
    public int Retry { get; set; } = 60;

    [DisplayName("Expire")]
    public int Expire { get; set; } = 60;

    [DisplayName("Minimum TTL")]
    public int MTTL { get; set; } = 60;

    [Required]
    [DisplayName("NS1")]
    [RegularExpression(@"[0-9aA-zZ]+\.[0-9aA-zZ]+\.[0-9aA-zZ]+", ErrorMessage = "Invalid format for nameserver")]
    public string NS1 { get; set; } = "";

    [Required]
    [DisplayName("NS2")]
    [RegularExpression(@"[0-9aA-zZ]+\.[0-9aA-zZ]+\.[0-9aA-zZ]+", ErrorMessage = "Invalid format for nameserver")]
    public string NS2 { get; set; } = "";

    [Required]
    [DisplayName("NS3")]
    [RegularExpression(@"[0-9aA-zZ]+\.[0-9aA-zZ]+\.[0-9aA-zZ]+", ErrorMessage = "Invalid format for nameserver")]
    public string NS3 { get; set; } = "";

    [Required]
    [DisplayName("NS4")]
    [RegularExpression(@"[0-9aA-zZ]+\.[0-9aA-zZ]+\.[0-9aA-zZ]+", ErrorMessage = "Invalid format for nameserver")]
    public string NS4 { get; set; } = "";

}

