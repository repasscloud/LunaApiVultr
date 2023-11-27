using System.Text.Json.Serialization;

namespace LunaApiVultr.Models
{
    public class NewInstance
    {
        // defaults to New Jersey
        [JsonPropertyName("region")]
        public string Region { get; set; } = "ewr";

        // defaults to the $3.5 plan
        [JsonPropertyName("plan")]
        public string Plan { get; set; } = "vc2-1c-0.5gb";

        // defaults to alpine linux
        [JsonPropertyName("os_id")]
        public int OsId { get; set; } = 2076;

        [JsonPropertyName("ipxe_chain_url")]
        public string? IpxeChainUrl { get; set; }

        [JsonPropertyName("iso_id")]
        public string? IsoId { get; set; }

        [JsonPropertyName("script_id")]
        public string? ScriptId { get; set; }

        [JsonPropertyName("snapshot_id")]
        public string? SnapshotId { get; set; }

        [JsonPropertyName("enable_ipv6")]
        public bool EnableIpv6 { get; set; } = true;

        [JsonPropertyName("disable_public_ipv4")]
        public bool DisablePublicIpv4 { get; set; } = false;

        // [JsonPropertyName("attach_private_network")]
        // public List<string> AttachPrivateNetwork { get; set; }

        [JsonPropertyName("attach_vpc")]
        public List<string>? AttachVpc { get; set; }

        [JsonPropertyName("attach_vpc2")]
        public List<string>? AttachVpc2 { get; set; }

        [JsonPropertyName("label")]
        public string? Label { get; set; }

        [JsonPropertyName("sshkey_id")]
        public List<string>? SshkeyId { get; set; }

        // backups are disabled, this is for VPN service
        [JsonPropertyName("backups")]
        public string Backups { get; set; } = "disabled";

        [JsonPropertyName("app_id")]
        public int? AppId { get; set; }

        [JsonPropertyName("image_id")]
        public string? ImageId { get; set; }

        [JsonPropertyName("user_data")]
        public string? UserData { get; set; }

        [JsonPropertyName("ddos_protection")]
        public bool? DdosProtection { get; set; }

        [JsonPropertyName("activation_email")]
        public bool? ActivationEmail { get; set; } = false;

        [JsonPropertyName("hostname")]
        public string? Hostname { get; set; }

        // [JsonPropertyName("tag")]
        // public string Tag { get; set; }

        [JsonPropertyName("firewall_group_id")]
        public string? FirewallGroupId { get; set; }

        [JsonPropertyName("reserved_ipv4")]
        public string? ReservedIpv4 { get; set; }

        // [JsonPropertyName("enable_private_network")]
        // public string EnablePrivateNetwork { get; set; }

        [JsonPropertyName("enable_vpc")]
        public bool? EnableVpc { get; set; }

        [JsonPropertyName("enable_vpc2")]
        public bool? EnableVpc2 { get; set; }

        [JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }

        [JsonPropertyName("user_scheme")]
        public string? UserScheme { get; set; }
    }
}