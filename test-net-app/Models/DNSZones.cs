using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test_net_app.Models;


public class DNSZones
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Doamin { get; set; } = "";

    [Required]
    [DisplayName("IP Address (IP4)")]
    public string IP { get; set; } = "";

    [Required]
    public string Email { get; set; } = "";

    [DisplayName("Time To Live")]
    public string TTL { get; set; } = "";

    [DisplayName("Time To Refresh")]
    public int Refresh { get; set; } = 60;

    [DisplayName("Time To Retry")]
    public int Retry { get; set; } = 60;

    [DisplayName("Time To Expire")]
    public int Expire { get; set; } = 60;

    [DisplayName("Minimum Time To Live")]
    public int MTTL { get; set; } = 60;

    [Required]
    [DisplayName("Nameserver 1")]
    public string NS1 { get; set; } = "";

    [Required]
    [DisplayName("Nameserver 2")]
    public string NS2 { get; set; } = "";

    [Required]
    [DisplayName("Nameserver 3")]
    public string NS3 { get; set; } = "";

    [Required]
    [DisplayName("Nameserver 4")]
    public string NS4 { get; set; } = "";

}

