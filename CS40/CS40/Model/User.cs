using System.ComponentModel.DataAnnotations.Schema;

namespace CS40;

[Table("TB_USER_INFO")]
public class User
{
    public int Id { get; set; }

    public DateTime CreateTime { get; set; }

    public string Account { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string ChName { get; set; } = string.Empty;

    public string VnName { get; set; } = string.Empty;

    public string EnName { get; set; } = string.Empty;

    public string Dept { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int Permission { get; set; }

    public string Remark { get; set; } = string.Empty;
}