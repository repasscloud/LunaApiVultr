using System.Text.Json.Serialization;

namespace LunaApiVultr.Models.Instances;
public class Instance
{
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("os")]
    public string? Os { get; set; }

    [JsonPropertyName("ram")]
    public int? Ram { get; set; }

    [JsonPropertyName("disk")]
    public int? Disk { get; set; }

    [JsonPropertyName("main_ip")]
    public string? MainIp { get; set; }

    [JsonPropertyName("vcpu_count")]
    public int? VcpuCount { get; set; }

    [JsonPropertyName("region")]
    public string? Region { get; set; }

    [JsonPropertyName("plan")]
    public string? Plan { get; set; }

    [JsonPropertyName("date_created")]
    public DateTime? DateCreated { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    [JsonPropertyName("allowed_bandwidth")]
    public int? AllowedBandwidth { get; set; }

    [JsonPropertyName("netmask_v4")]
    public string? NetmaskV4 { get; set; }

    [JsonPropertyName("gateway_v4")]
    public string? GatewayV4 { get; set; }

    [JsonPropertyName("power_status")]
    public string? PowerStatus { get; set; }

    [JsonPropertyName("server_status")]
    public string? ServerStatus { get; set; }

    [JsonPropertyName("v6_network")]
    public string? V6Network { get; set; }

    [JsonPropertyName("v6_main_ip")]
    public string? V6MainIp { get; set; }

    [JsonPropertyName("v6_network_size")]
    public int? V6NetworkSize { get; set; }

    [JsonPropertyName("label")]
    public string? Label { get; set; }

    [JsonPropertyName("internal_ip")]
    public string? InternalIp { get; set; }

    [JsonPropertyName("kvm")]
    public string? Kvm { get; set; }

    [JsonPropertyName("hostname")]
    public string? Hostname { get; set; }

    [JsonPropertyName("tag")]
    public string? Tag { get; set; }

    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    [JsonPropertyName("os_id")]
    public int? OsId { get; set; }

    [JsonPropertyName("app_id")]
    public int? AppId { get; set; }

    [JsonPropertyName("image_id")]
    public string? ImageId { get; set; }

    [JsonPropertyName("firewall_group_id")]
    public string? FirewallGroupId { get; set; }

    [JsonPropertyName("features")]
    public List<object>? Features { get; set; }

    [JsonPropertyName("user_scheme")]
    public string? UserScheme { get; set; }

    [JsonPropertyName("default_password")]
    public string? DefaultPassword { get; set; }
}