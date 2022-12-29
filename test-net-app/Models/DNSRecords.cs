using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test_net_app.Models;


public class DNSRecords
{
    [Key]
    public int Id { get; set; } = 0;

    public int ZoneId { get; set; } = 0;

    public string Name { get; set; } = "";
    public int TTL { get; set; } = 60;
    public string RecordClass { get; set; } = "IN";
    public string RecordType { get; set; } = "A";
    public string RecordData { get; set; } = "";

}

